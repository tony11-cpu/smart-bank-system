using SmartBack_DAL;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    public class clsTransactionLog
    {
        public enum enTransactionType { Deposit, Withdrawal, Transfer_In, Transfer_Out, Scheduled }
        public enTransactionType TransactionType { get; private set; }
        public int TransactionID { get; private set; }
        public clsAccounts FromAccount { get; private set; }
        /// <summary>
        /// For deposits & withdrawals this will be null. For transfers, this will be the account from which the money is withdrawn.
        /// </summary>
        public clsAccounts ToAccount { get; private set; } = null;
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public int UserResponsibleID { get; private set; }
        public bool IsScheduled { get; private set; }
        public (decimal FromAccount_BalanceAfter, decimal ToAccountBalanceAfter) BalanceAfterTransaction { get; private set; }

        public clsTransactionLog(int transactionID, enTransactionType transactionType, clsAccounts fromAccount, clsAccounts toAccount,
                                decimal amount, string description, DateTime transactionDate, int userResponsibleID, bool isScheduled)
        {
            this.TransactionID = transactionID;
            this.TransactionType = transactionType;
            this.FromAccount = fromAccount;
            this.ToAccount = toAccount;
            this.Amount = amount;
            this.Description = description;
            this.TransactionDate = transactionDate;
            this.UserResponsibleID = userResponsibleID;
            this.IsScheduled = isScheduled;
        }

        public static async Task<List<clsTransactionLog>> GetAllTransactionsAsync()
        {
            DataTable dt = await clsTransactions_DAL.GetAllTransactionsAsync();
            if (dt == null || dt.Rows.Count == 0) return new List<clsTransactionLog>();

            var cache = new ConcurrentDictionary<int, Task<clsAccounts>>();
            return (await Task.WhenAll(dt.Rows.Cast<DataRow>().Select(async row => {string normalized = row.Field<string>("TransactionType").Replace(" ", "_");
                enTransactionType type = Enum.TryParse<enTransactionType>(normalized, out var r) ? r : (normalized.Contains("Transfer") ? enTransactionType.Transfer_In : enTransactionType.Scheduled);
                var fromAccount = await cache.GetOrAdd(row.Field<int>("AccountID"), clsAccounts.FindAsync);
                clsAccounts toAccount = row.Field<int?>("RelatedAccountID") is int rid ? await cache.GetOrAdd(rid, clsAccounts.FindAsync) : null;
                return new clsTransactionLog(row.Field<int>("TransactionID"), type, fromAccount, toAccount,
                    row.Field<decimal>("Amount"), row.Field<string>("Description") is "No Description" ? null : row.Field<string>("Description"),
                    row.Field<DateTime>("TransactionDate"), row.Field<int>("ProcessedByUserID"), row.Field<bool>("IsScheduled"));}))).ToList();
        }

        public static async Task<List<clsTransactionLog>> GetAllUserTransactionsListAsync(int? userID) 
        {
            var allTransactions = await GetAllTransactionsAsync();
            if (!userID.HasValue || allTransactions == null)
                return new List<clsTransactionLog>();
            return allTransactions.Where(t => t.UserResponsibleID == userID.Value).ToList();
        }

        public static async Task<clsTransactionLog> FindAsyncWithAccountID(int accountID)
        {
            clsTransactionDto transactionInfo = await clsTransactions_DAL.GetLatestTransactionByAccountIDAsync(accountID);
            if (transactionInfo == null) 
                return null;

            clsAccounts fromAccount = await clsAccounts.FindAsync(transactionInfo.AccountID);
            if (fromAccount == null)
                return null;

            string normalized = transactionInfo.TransactionType.Replace(" ", "_");
            enTransactionType type = Enum.TryParse<enTransactionType>(normalized, out var r) ? r : (normalized.Contains("Transfer") ? enTransactionType.Transfer_In : enTransactionType.Scheduled);
            return new clsTransactionLog(transactionInfo.TransactionID, type,
                fromAccount, transactionInfo.RelatedAccountID.HasValue ? await clsAccounts.FindAsync(transactionInfo.RelatedAccountID.Value) : null,
                transactionInfo.Amount, transactionInfo.Description, transactionInfo.TransactionDate, transactionInfo.ProcessedByUserID, transactionInfo.IsScheduled);
        }

        public static async Task<clsTransactionLog> FindAsyncWithTransactionID(int transactionID)
        {
            clsTransactionDto transactionInfo = await clsTransactions_DAL.GetTransactionByIDAsync(transactionID);
            if (transactionInfo == null)
                return null;

            clsAccounts fromAccount = await clsAccounts.FindAsync(transactionInfo.AccountID);
            if (fromAccount == null)
                return null;

            string normalized = transactionInfo.TransactionType.Replace(" ", "_");
            enTransactionType type = Enum.TryParse<enTransactionType>(normalized, out var r) ? r : (normalized.Contains("Transfer") ? enTransactionType.Transfer_In : enTransactionType.Scheduled);
            return new clsTransactionLog(transactionInfo.TransactionID, type,
                fromAccount, transactionInfo.RelatedAccountID.HasValue ? await clsAccounts.FindAsync(transactionInfo.RelatedAccountID.Value) : null,
                transactionInfo.Amount, transactionInfo.Description, transactionInfo.TransactionDate, transactionInfo.ProcessedByUserID, transactionInfo.IsScheduled);
        }
    }
}
