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
        public enum enTransactionType { Deposit, Withdrawal, Transfer_In, Transfer_Out , Scheduled }
        public enTransactionType TransactionType { get; private set; }
        public int TransactionID { get; private set; }
        public clsAccounts FromAccount { get; private set; }
        /// <summary>
        /// For deposits & withdrawls this will be null. Transfers, this will be the account from which the money is withdrawn.
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
            return (await Task.WhenAll(dt.Rows.Cast<DataRow>().Select(async row => new clsTransactionLog(
                row.Field<int>("TransactionID"),
                (enTransactionType)Enum.Parse(typeof(enTransactionType),
                row.Field<string>("TransactionType").Replace(" ", "_")),
                await cache.GetOrAdd(row.Field<int>("AccountID"), clsAccounts.FindAsync),
                row.Field<int?>("RelatedAccountID") is int rid ? 
                await cache.GetOrAdd(rid, clsAccounts.FindAsync) : new clsAccounts { AccountNumber = "No Related Account" },
                row.Field<decimal>("Amount"),
                row.Field<string>("Description") is "No Description" ? null : row.Field<string>("Description"),
                row.Field<DateTime>("TransactionDate"),
                row.Field<int>("ProcessedByUserID"),
                row.Field<bool>("IsScheduled")
            )))).ToList();
        }

        public static async Task<List<clsTransactionLog>> GetAllUserTransactionsList(int? userID) => userID.HasValue ? (await GetAllTransactionsAsync()).Where(t => t.UserResponsibleID == userID).ToList() : new List<clsTransactionLog>();
    }
}
