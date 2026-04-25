using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    public class clsTransactionLog
    {
        public enum enTransactionType { Deposit, Withdrawal, Transfer_In, Transfer_Out }
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
            DataTable dt = clsTransactions_DAL.GetAllTransactions();
            if (dt == null || dt.Rows.Count == 0) return new List<clsTransactionLog>();

            
            var accountCache = new Dictionary<int, clsAccounts>();

            async Task<clsAccounts> GetAccountFromCache(int? id)
            {
                if (id == null) return null;
                if (!accountCache.ContainsKey(id.Value))
                    accountCache[id.Value] = await clsAccounts.FindAsync(id.Value);
                return accountCache[id.Value];
            }

            var transactionList = new List<clsTransactionLog>();

            foreach (DataRow row in dt.Rows)
            {
                int accountId = row.Field<int>("AccountID");
                int? relatedAccountId = row.Field<int?>("RelatedAccountID");
                string typeRaw = row.Field<string>("TransactionType").Replace(" ", "_");
                string desc = row.Field<string>("Description");

                transactionList.Add(new clsTransactionLog(
                    row.Field<int>("TransactionID"),
                    (enTransactionType)Enum.Parse(typeof(enTransactionType), typeRaw),
                    await GetAccountFromCache(accountId),
                    await GetAccountFromCache(relatedAccountId),
                    row.Field<decimal>("Amount"),
                    desc == "No Description" ? null : desc,
                    row.Field<DateTime>("TransactionDate"),
                    row.Field<int>("ProcessedByUserID"),
                    row.Field<bool>("IsScheduled")
                ));
            }

            return transactionList;
        }

        public static async Task<List<clsTransactionLog>> GetAllUserTransactionsList(int? userID) => userID.HasValue ? (await GetAllTransactionsAsync()).Where(t => t.UserResponsibleID == userID).ToList() : new List<clsTransactionLog>();
    }
}
