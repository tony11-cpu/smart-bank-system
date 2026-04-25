using SmartBank;
using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    public class clsAccounts
    {
        public enum enMode { Add, Update }
        public enum enAccountType { Savings, Checking }
        public enum enStatus { Active, Frozen, Closed }

        private enMode _mode;
        public int? AccountID { get; private set; }
        public string AccountNumber { get; set; }
        public clsCustomers Customer { get; set; }
        public enAccountType AccountType { get; set; }

        private decimal _minimumBalance;
        public decimal MinimumBalance
        {
            get => _minimumBalance;
            set
            {
                if (Balance < value && _mode == enMode.Update)
                    throw new InvalidOperationException("Cannot set minimum balance higher than current balance.");

                _minimumBalance = value;
            }
        }

        /// <summary>
        /// Can change only through transactions. Use the transactions class.
        /// </summary>
        public decimal Balance { get; internal set; }
        public enStatus Status { get; private set; }
        public DateTime? OpenedDate { get; private set; }
        public DateTime? ClosedDate { get; private set; }
        public int CreatedByUserID { get; set; }
        public static async Task<int> NumberOfActiveAccountsAsync() => (await GetAllAccountsAsync()).Where(n => n.Status == enStatus.Active).Count();

        public clsAccounts(int accountID, string accountNumber, int customerID,
                           enAccountType accountType, decimal balance, decimal minimumBalance,
                           enStatus status, DateTime? openedDate, DateTime? closedDate,
                           int createdByUserID)
        {
            Customer = clsCustomers.Find(customerID);
            if (Customer == null)
                throw new Exception("Customer not found for the given CustomerID.");

            AccountID = accountID;
            AccountNumber = accountNumber;
            AccountType = accountType;
            Balance = balance;
            MinimumBalance = minimumBalance;
            Status = status;
            OpenedDate = openedDate;
            ClosedDate = closedDate;
            CreatedByUserID = createdByUserID;

            _mode = enMode.Update;
        }

        public clsAccounts()
        {
            AccountID = null;
            AccountNumber = null;
            Customer = null;
            AccountType = enAccountType.Savings;
            Balance = 0;
            MinimumBalance = 0;
            Status = enStatus.Closed;
            OpenedDate = null;
            ClosedDate = null;
            CreatedByUserID = -1;

            _mode = enMode.Add;
        }

        public static async Task<bool> IsAccountExistsAsync(int accountID) => await clsAccounts_DAL.IsAccountExistsByIDAsync(accountID);

        public static async Task<bool> IsAccountExistsAsync(string accountNumber) => await clsAccounts_DAL.IsAccountExistsByNumberAsync(accountNumber);

        public static async Task<clsAccounts> FindAsync(int accountID)
        {
            clsAccountsDto accountInfo = await clsAccounts_DAL.GetAccountByIDAsync(accountID, null);
            if (accountInfo != null)
            {
                return new clsAccounts(accountID, accountInfo.AccountNumber, accountInfo.CustomerID,
                                       (enAccountType)Enum.Parse(typeof(enAccountType), accountInfo.AccountType),
                                       accountInfo.Balance, accountInfo.MinimumBalance,
                                       (enStatus)Enum.Parse(typeof(enStatus), accountInfo.Status),
                                       accountInfo.OpenedDate, accountInfo.ClosedDate, accountInfo.CreatedByUserID);
            }

            return null;
        }

        public static async Task<clsAccounts> FindAsync(string accountNumber)
        {
            clsAccountsDto accountInfo = await clsAccounts_DAL.GetAccountByNumberAsync(accountNumber, null);
            if (accountInfo != null)
            {
                return new clsAccounts(accountInfo.AccountID, accountInfo.AccountNumber, accountInfo.CustomerID,
                                       (enAccountType)Enum.Parse(typeof(enAccountType), accountInfo.AccountType), accountInfo.Balance, accountInfo.MinimumBalance,
                                       (enStatus)Enum.Parse(typeof(enStatus), accountInfo.Status), accountInfo.OpenedDate, accountInfo.ClosedDate, accountInfo.CreatedByUserID);
            }

            return null;
        }

        private async Task<bool> _addNewAsync()
        {
            AccountID = await clsAccounts_DAL.CreateAccountAsync(clsGlobal.ActiveUser.UserID ?? throw new Exception("No Admin Responsible!"),
                                                                  Customer.CustomerID ?? throw new Exception("No Customer Responsible"),
                                                                  AccountNumber, AccountType.ToString(), Balance, MinimumBalance);
            return AccountID != -1;
        }

        private async Task<bool> _updateAsync() => await clsAccounts_DAL.UpdateAccountAsync(clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible!"),
                                                                                       AccountID ?? throw new Exception("Account ID is not set for update!"),
                                                                                       AccountType.ToString(), MinimumBalance);

        public async Task<bool> SaveAsync()
        {
            switch (_mode)
            {
                case enMode.Add:
                    if (await _addNewAsync())
                    {
                        _mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update: return await _updateAsync();
                default:
                    throw new InvalidOperationException("Invalid mode for saving account.");
            }
        }

        /// <summary>
        /// Use try and catch while calling this method to handle exceptions and provide user-friendly messages.
        /// </summary>
        /// <returns>True if the account was successfully unfrozen; otherwise, false.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the account is not in a frozen state.</exception>
        /// <exception cref="Exception">Thrown when there is no user responsible or account ID is not set.</exception>
        public async Task<bool> UnFreezeAsync()
        {
            if (Status != enStatus.Frozen)
                throw new InvalidOperationException("Only frozen accounts can be unfrozen.");

            if (_mode == enMode.Update && await clsAccounts_DAL.UnfreezeAccountAsync(clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible"),
                                                                                     AccountID ?? throw new Exception("Account ID is not set!")))
            {
                Status = enStatus.Active;
                return true;
            }

            return false;
        }

        // Note: Check For Pending Transactions Before Freezing Account, This Logic Should Be Implemented In The Calling Code To Ensure Separation Of Concerns And Single Responsibility Principle.
        /// <summary>
        /// Use try and catch while calling this method to handle exceptions and provide user-friendly messages.
        /// </summary>
        /// <returns>True if the account was successfully frozen; otherwise, false.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the account is not in an active state.</exception>
        /// <exception cref="Exception">Thrown when there is no user responsible or account ID is not set.</exception>
        public async Task<bool> FreezeAsync()
        {
            if (Status != enStatus.Active)
                throw new InvalidOperationException("Only active accounts can be frozen.");

            if (_mode == enMode.Update && await clsAccounts_DAL.FreezeAccountAsync(clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible"),
                                                                                   AccountID ?? throw new Exception("Account ID is not set!")))
            {
                Status = enStatus.Frozen;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Use try and catch while calling this method to handle exceptions and provide user-friendly messages.
        /// </summary>
        /// <returns>True if the account was successfully closed; otherwise, false.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the account is not in a closable state.</exception>
        /// <exception cref="Exception">Thrown when there is no user responsible or account ID is not set.</exception>
        public async Task<bool> CloseAsync()
        {
            if (this.Balance > 0)
                throw new InvalidOperationException("Only accounts with zero balance can be closed.");

            if (Status == enStatus.Closed)
                throw new InvalidOperationException("Account is already closed.");

            if (_mode == enMode.Update && await clsAccounts_DAL.CloseAccountAsync(clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible"),
                                                                                  AccountID ?? throw new Exception("Account ID is not set!")))
            {
                Status = enStatus.Closed;
                ClosedDate = DateTime.Now;
                return true;
            }

            return false;
        }

        public static async Task<List<clsAccounts>> GetAllAccountsAsync()
        {
            DataTable dt = await clsAccounts_DAL.GetAllAccountsAsync();
            if (dt == null)
                return null;

            List<clsAccounts> accounts = new List<clsAccounts>();
            foreach (DataRow row in dt.Rows)
            {
                accounts.Add(new clsAccounts
                (
                    Convert.ToInt32(row["AccountID"]),
                    row["AccountNumber"].ToString(),
                    Convert.ToInt32(row["CustomerID"]),
                    (enAccountType)Enum.Parse(typeof(enAccountType), row["AccountType"].ToString()),
                    Convert.ToDecimal(row["Balance"]),
                    Convert.ToDecimal(row["MinimumBalance"]),
                    (enStatus)Enum.Parse(typeof(enStatus), row["Status"].ToString()),
                    Convert.ToDateTime(row["OpenedDate"]),
                    row["ClosedDate"] as DateTime?,
                    Convert.ToInt32(row["CreatedByUserID"])
                ));
            }

            return accounts;
        }

        public static async Task<List<clsAccounts>> GetAccountsByCustomerIDAsync(int customerID)
        {
            DataTable dt = await clsAccounts_DAL.GetAccountsByCustomerIDAsync(customerID);
            if (dt == null)
                return null;

            List<clsAccounts> accounts = new List<clsAccounts>();

            foreach (DataRow row in dt.Rows)
            {
                accounts.Add(new clsAccounts(
                    (int)row["AccountID"],
                              row["AccountNumber"].ToString(),
                    (int)row["CustomerID"],
                    (enAccountType)Enum.Parse(typeof(enAccountType), row["AccountType"].ToString()),
                    (decimal)row["Balance"],
                    (decimal)row["MinimumBalance"],
                    (enStatus)Enum.Parse(typeof(enStatus), row["Status"].ToString()),
                    (DateTime)row["OpenedDate"],
                    row["ClosedDate"] == DBNull.Value
                              ? (DateTime?)null
                              : (DateTime)row["ClosedDate"],
                    (int)row["CreatedByUserID"]
                ));
            }

            return accounts;
        }

        /// <summary>
        /// Use try and catch while calling this method to handle exceptions and provide user-friendly messages.
        /// </summary>
        /// <returns>True if the deposit was successful, otherwise false.</returns>
        /// <exception cref="Exception">Throws an exception if the user responsible is not set.</exception>
        public async Task<bool> DepositAsync(decimal amount, string description)
        {
            if (await clsPerformTransaction.Deposit(this.AccountID ?? throw new Exception("Account Not Setted!"), amount, description, clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible"), false))
            {
                this.Balance += amount;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Use try and catch while calling this method to handle exceptions and provide user-friendly messages.
        /// </summary>
        /// <returns>True if the withdrawal was successful, otherwise false.</returns>
        /// <exception cref="Exception">Throws an exception if the user responsible is not set.</exception>
        public async Task<bool> WithdrawAsync(decimal amount, string description)
        {
            if (await clsPerformTransaction.Withdraw(this.AccountID, amount, description, clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible"), false))
            {
                this.Balance -= amount;
                return true;
            }

            return false;
        }


        /// <summary>
        /// Use try and catch while calling this method to handle exceptions and provide user-friendly messages.
        /// </summary>
        /// <returns>True if the transfer was successful, otherwise false.</returns>
        /// <exception cref="Exception">Throws an exception if: the account ID is not set, the destination account ID is not set, or the user responsible is not set.</exception>
        public async Task<bool> TransferToAsync(clsAccounts toAccount, decimal amount, string description)
        {
            if (await clsPerformTransaction.Transfer(this.AccountID ?? throw new Exception("Account ID is not set!"),
                toAccount.AccountID ?? throw new Exception("Destination Account ID is not set!"),
                amount, description, clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible") , false))
            {
                this.Balance -= amount;
                toAccount.Balance += amount;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Use try and catch while calling this method to handle exceptions and provide user-friendly messages.
        /// </summary>
        /// <returns>True if the scheduled transfer was successful, otherwise false.</returns>
        /// <exception cref="Exception">Throws an exception if: the account ID is not set, the destination account ID is not set, the user responsible is not set, or the scheduled date is invalid.</exception>
        public async Task<bool> ScheduleTransferToAsync(clsAccounts toAccount, decimal amount, string description, DateTime scheduledDate) =>
            await clsPerformTransaction.ScheduleTransfer(this.AccountID ?? throw new Exception("Account ID is not set!"), toAccount.AccountID ?? throw new Exception("Destination Account ID is not set!"),
             amount, description, scheduledDate, clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible"));

        public override string ToString() => $"{AccountNumber}";
    }
}