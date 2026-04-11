using SmartBank;
using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartBank_BLL
{
    public interface ITransactions
    {
        bool Deposit(int accountID, decimal amount, string description, int performedByUserID);
        bool Withdraw(int accountID, decimal amount, string description, int performedByUserID);
        bool Transfer(int fromAccountID, int toAccountID, decimal amount, string description, int performedByUserID);
        bool ScheduleTransfer(int fromAccountID, int toAccountID, decimal amount, string description, DateTime scheduledDate, int performedByUserID);
    }

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

        /// <summary>
        /// Can change only through transactions. Use the transactions class.
        /// </summary>
        public decimal Balance { get; internal set; }

        private decimal _minimumBalance;
        public decimal MinimumBalance
        { 
            get => _minimumBalance; 
            set
            {
                if(value < 0)
                    throw new ArgumentOutOfRangeException("MinimumBalance cannot be negative.");

                if(Balance < value)
                    throw new InvalidOperationException("Cannot set minimum balance higher than current balance.");

                _minimumBalance = value;
            }
        }
        public enStatus Status { get; private set; }
        public DateTime? OpenedDate { get; private set; }
        public DateTime? ClosedDate { get; private set; }
        public int CreatedByUserID { get; set; }

        public clsAccounts(int accountID, string accountNumber, int customerID,
                           enAccountType accountType, decimal balance, decimal minimumBalance,
                           enStatus status, DateTime? openedDate, DateTime? closedDate,
                           int createdByUserID)
        {
            Customer = clsCustomers.Find(customerID);
            if(Customer == null)
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

        public static bool IsAccountExists(int accountID) => clsAccounts_DAL.IsAccountExistsByID(accountID);

        public static bool IsAccountExists(string accountNumber) => clsAccounts_DAL.IsAccountExistsByNumber(accountNumber);

        public static clsAccounts Find(int accountID)
        {
            string accountNumber = null;
            int customerID = -1;
            string accountType = null;
            decimal balance = 0;
            decimal minimumBalance = 0;
            string status = null;
            DateTime? openedDate = null;
            DateTime? closedDate = null;
            int createdByUserID = -1;

            if (clsAccounts_DAL.GetAccountByID(accountID,
                    ref accountNumber, ref customerID, ref accountType,
                    ref balance, ref minimumBalance, ref status,
                    ref openedDate, ref closedDate, ref createdByUserID))
            {
                return new clsAccounts(accountID, accountNumber, customerID,
                                       (enAccountType)Enum.Parse(typeof(enAccountType), accountType), balance, minimumBalance,
                                       (enStatus)Enum.Parse(typeof(enStatus), status), openedDate, closedDate, createdByUserID);
            }

            return null;
        }

        public static clsAccounts Find(string accountNumber)
        {
            int accountID = -1;
            int customerID = -1;
            string accountType = null;
            decimal balance = 0;
            decimal minimumBalance = 0;
            string status = null;
            DateTime? openedDate = null;
            DateTime? closedDate = null;
            int createdByUserID = -1;

            if (clsAccounts_DAL.GetAccountByNumber(accountNumber,
                    ref accountID, ref customerID, ref accountType,
                    ref balance, ref minimumBalance, ref status,
                    ref openedDate, ref closedDate, ref createdByUserID))
            {
                return new clsAccounts(accountID, accountNumber, customerID,
                                       (enAccountType)Enum.Parse(typeof(enAccountType), accountType), balance, minimumBalance,
                                       (enStatus)Enum.Parse(typeof(enStatus), status), openedDate, closedDate, createdByUserID);
            }
            return null;
        }

        private bool _addNew()
        {
            AccountID = clsAccounts_DAL.CreateAccount(clsGlobal.ActiveUser.UserID ?? throw new Exception("No Admin Responsible!"),
                                                      Customer.CustomerID ?? throw new Exception("No Customer Responsible"),
                                                      AccountNumber , AccountType.ToString(), Balance, MinimumBalance);

            return AccountID != -1;
        }

        private bool _update() => clsAccounts_DAL.UpdateAccount(clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible!"),
                                                                AccountID ?? throw new Exception("Account ID is not set for update!"),
                                                                AccountType.ToString(), MinimumBalance);

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.Add:
                    if (_addNew())
                    {
                        _mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update: return _update();
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
        public bool UnFreeze()
        {
            if(Status != enStatus.Frozen)
                throw new InvalidOperationException("Only frozen accounts can be unfrozen.");

            if (_mode == enMode.Update && clsAccounts_DAL.UnfreezeAccount(clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible") , 
                                                                          AccountID ?? throw new Exception("Account ID is not set!")))
            {
                Status = enStatus.Active;
                return true;
            }

            return false;
        }

        // Note: Check For Pending Transactions Befovre Freezing Account, This Logic Should Be Implemented In The Calling Code To Ensure Separation Of Concerns And Single Responsibility Principle.
        /// <summary>
        /// Use try and catch while calling this method to handle exceptions and provide user-friendly messages.
        /// </summary>
        /// <returns>True if the account was successfully frozen; otherwise, false.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the account is not in an active state.</exception>
        /// <exception cref="Exception">Thrown when there is no user responsible or account ID is not set.</exception>
        public bool Freeze()
        {
            if(Status != enStatus.Active)
                throw new InvalidOperationException("Only active accounts can be frozen.");

            if (_mode == enMode.Update && clsAccounts_DAL.FreezeAccount(clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible"),
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
        public bool Close()
        {
            if(this.Balance > 0)
                throw new InvalidOperationException("Only accounts with zero balance can be closed.");

            if (Status == enStatus.Closed)
                throw new InvalidOperationException("Account is already closed.");

            if (_mode == enMode.Update && clsAccounts_DAL.CloseAccount(clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible"),
                                                                       AccountID ?? throw new Exception("Account ID is not set!")))
            {
                Status = enStatus.Closed;
                ClosedDate = DateTime.Now;
                return true;
            }

            return false;
        }

        public static List<clsAccounts> GetAllAccounts()
        {
            DataTable dt = clsAccounts_DAL.GetAllAccounts(); 
            if (dt == null) return null;

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

        public static List<clsAccounts> GetAccountsByCustomerID(int customerID)
        {
            DataTable dt = clsAccounts_DAL.GetAccountsByCustomerID(customerID);
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
    }
}