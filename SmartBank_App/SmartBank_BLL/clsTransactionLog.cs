using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    public class clsTransactionLog
    {
        public enum enTransactionType { Deposit, Withdrawal, Transfer_In, Transfer_Out, Scheduled }
        public enTransactionType TransactionType { get; private set; }
        public int TransactionID { get; private set; }
        public clsAccounts FromAccount { get; private set; }
        public clsAccounts ToAccount { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public int UserResponsibleID { get; private set; }
        public bool IsScheduled { get; private set; }
        public decimal BalanceAfterTransaction { get; private set; }
        public decimal BalanceBeforeTransaction { get; private set; }

        public clsTransactionLog(int transactionID, enTransactionType transactionType, clsAccounts fromAccount, clsAccounts toAccount,
                                decimal amount, string description, DateTime transactionDate, int userResponsibleID, bool isScheduled,
                                decimal balanceAfterTransaction = 0, decimal balanceBeforeTransaction = 0)
        {
            TransactionID = transactionID;
            TransactionType = transactionType;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
            UserResponsibleID = userResponsibleID;
            IsScheduled = isScheduled;
            BalanceAfterTransaction = balanceAfterTransaction;
            BalanceBeforeTransaction = balanceBeforeTransaction;
        }

        public static async Task<List<clsTransactionLog>> GetAllTransactionsAsync()
        {
            DataTable dt = await clsTransactions_DAL.GetAllTransactionsAsync();
            if (dt == null || dt.Rows.Count == 0)
                return new List<clsTransactionLog>();

            List<clsTransactionLog> transactions = new List<clsTransactionLog>();
            Dictionary<int, clsAccounts> accountsCache = new Dictionary<int, clsAccounts>();

            foreach (DataRow row in dt.Rows)
            {
                clsAccounts fromAccount = await _getAccountFromCacheAsync(accountsCache, (int)row["AccountID"]);
                clsAccounts toAccount = row["RelatedAccountID"] == DBNull.Value ? null : await _getAccountFromCacheAsync(accountsCache, (int)row["RelatedAccountID"]);

                string description = row["Description"]?.ToString();
                description = description == "No Description" ? null : description;

                transactions.Add(new clsTransactionLog((int)row["TransactionID"], _parseTransactionType(row["TransactionType"].ToString().Replace(" ", "_")),
                    fromAccount, toAccount, (decimal)row["Amount"], description, (DateTime)row["TransactionDate"],
                    (int)row["ProcessedByUserID"], (bool)row["IsScheduled"], _getBalance(row, "BalanceAfter"), _getBalance(row, "BalanceBefore")
                ));
            }

            return transactions;
        }

        private static async Task<clsAccounts> _getAccountFromCacheAsync(Dictionary<int, clsAccounts> accountsCache, int accountID)
        {
            if (accountsCache.TryGetValue(accountID, out clsAccounts account))
                return account;

            account = await clsAccounts.FindAsync(accountID);
            accountsCache[accountID] = account;
            return account;
        }

        private static decimal _getBalance(DataRow row, string columnName)
        {
            foreach (DataColumn col in row.Table.Columns)
            {
                if (col.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase) && row[col] != DBNull.Value)
                    return Convert.ToDecimal(row[col]);
            }
            return 0;
        }

        private static enTransactionType _parseTransactionType(string typeString)
        {
            if (Enum.TryParse<enTransactionType>(typeString, out enTransactionType type))
                return type;

            if (typeString.Contains("Transfer") || typeString.Contains("Transfare"))
                return enTransactionType.Transfer_In;

            if (typeString.Contains("Withdrawal") || typeString.Contains("Withdraw"))
                return enTransactionType.Withdrawal;

            if (typeString.Contains("Deposit"))
                return enTransactionType.Deposit;

            if (typeString.Contains("Scheduled"))
                return enTransactionType.Scheduled;

            return enTransactionType.Scheduled;
        }

        public static async Task<List<clsTransactionLog>> GetAllUserTransactionsListAsync(int? userID) 
        {
            List<clsTransactionLog> allTransactions = await GetAllTransactionsAsync();
            if (!userID.HasValue || allTransactions == null)
                return new List<clsTransactionLog>();

            return allTransactions.Where(t => t.UserResponsibleID == userID.Value).ToList();
        }

        public static async Task<clsTransactionLog> FindAsyncWithAccountID(int accountID)
        {
            clsTransactionDto dto = await clsTransactions_DAL.GetLatestTransactionByAccountIDAsync(accountID);
            return dto == null ? null : await _createTransactionFromDto(dto);
        }

        public static async Task<clsTransactionLog> FindAsyncWithTransactionID(int transactionID)
        {
            clsTransactionDto dto = await clsTransactions_DAL.GetTransactionByIDAsync(transactionID);
            return dto == null ? null : await _createTransactionFromDto(dto);
        }

        private static async Task<clsTransactionLog> _createTransactionFromDto(clsTransactionDto dto)
        {
            clsAccounts fromAccount = await clsAccounts.FindAsync(dto.AccountID);
            if (fromAccount == null)
                return null;

            clsAccounts toAccount = null;
            if (dto.RelatedAccountID.HasValue)
                toAccount = await clsAccounts.FindAsync(dto.RelatedAccountID.Value);

            enTransactionType type = _parseTransactionType(dto.TransactionType.Replace(" ", "_"));
            return new clsTransactionLog(dto.TransactionID, type, fromAccount, toAccount, dto.Amount, dto.Description, 
                                         dto.TransactionDate, dto.ProcessedByUserID, dto.IsScheduled, dto.BalanceAfter, dto.BalanceBefore);
        }
    }
}
