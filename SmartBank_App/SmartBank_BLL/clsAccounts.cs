using SmartBank;
using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartBank_BLL
{
    public class clsAccounts
    {
        public enum enMode { Add, Update }
        public enum enAccountType { Savings, Checking }
        public enum enStatus { Active, Frozen, Closed }

        private enMode _mode;
        public int? AccountID { get; private set; }
        public string AccountNumber { get; private set; }
        public clsCustomers Customer { get; set; }
        public enAccountType AccountType { get; set; }
        public decimal Balance { get; private set; }
        public decimal MinimumBalance { get; set; }
        public enStatus Status { get; private set; }
        public DateTime? OpenedDate { get; private set; }
        public DateTime? ClosedDate { get; private set; }
        public int CreatedByUserID { get; private set; }

        public clsAccounts(int accountID, string accountNumber, int customerID,
                           enAccountType accountType, decimal balance, decimal minimumBalance,
                           enStatus status, DateTime? openedDate, DateTime? closedDate,
                           int createdByUserID)
        {
            AccountID = accountID;
            AccountNumber = accountNumber;
            Customer = clsCustomers.Find(customerID);
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
                Customer.CustomerID ?? throw new Exception("No Customer Responsible"),AccountNumber , AccountType.ToString(), MinimumBalance);

            if (AccountID == -1)
                return false;

            _mode = enMode.Update;
            return true;
        }

        private bool _update() => clsAccounts_DAL.UpdateAccount(clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Resposible!"),
                                                                AccountID ?? throw new Exception("Account ID is not set for update!"),
                                                                AccountType.ToString(), MinimumBalance);

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.Add: return _addNew();
                case enMode.Update: return _update();

                default:
                    throw new InvalidOperationException("Invalid mode for saving account.");
            }
        }

        public bool UnFreeze()
        {
            if (_mode == enMode.Update && clsAccounts_DAL.UnfreezeAccount(clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible") , 
                                                                          AccountID ?? throw new Exception("Account ID is not set!")))
            {
                Status = enStatus.Active;
                return true;
            }

            return false;
        }

        public bool Freeze()
        {
            if (_mode == enMode.Update && clsAccounts_DAL.FreezeAccount(clsGlobal.ActiveUser.UserID ?? throw new Exception("No User Responsible"),
                                                                         AccountID ?? throw new Exception("Account ID is not set!")))
            {
                Status = enStatus.Frozen;
                return true;
            }

            return false;
        }

        public bool Close()
        {
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