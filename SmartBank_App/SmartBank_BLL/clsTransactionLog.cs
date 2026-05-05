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
        public (decimal FromAccount_BalanceAfter, decimal ToAccountBalanceAfter) BalanceAfterTransaction { get; private set; }

        public clsTransactionLog(int transactionID, enTransactionType transactionType, clsAccounts fromAccount, clsAccounts toAccount,
                                decimal amount, string description, DateTime transactionDate, int userResponsibleID, bool isScheduled)
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
        }

        public static async Task<List<clsTransactionLog>> GetAllTransactionsAsync()
        {
            DataTable dt = await clsTransactions_DAL.GetAllTransactionsAsync();
            if (dt == null || dt.Rows.Count == 0)
                return new List<clsTransactionLog>();

            List<clsTransactionLog> transactions = new List<clsTransactionLog>();

            foreach (DataRow row in dt.Rows)
            {
                int accountID = (int)row["AccountID"];
                clsAccounts fromAccount = await clsAccounts.FindAsync(accountID);

                clsAccounts toAccount = null;
                if (row["RelatedAccountID"] != DBNull.Value)
                {
                    int relatedID = (int)row["RelatedAccountID"];
                    toAccount = await clsAccounts.FindAsync(relatedID);
                }

                string typeString = row["TransactionType"].ToString().Replace(" ", "_");
                enTransactionType type = _parseTransactionType(typeString);

                string description = row["Description"]?.ToString();
                if (description == "No Description")
                    description = null;

                clsTransactionLog transaction = new clsTransactionLog(
                    (int)row["TransactionID"],
                    type,
                    fromAccount,
                    toAccount,
                    (decimal)row["Amount"],
                    description,
                    (DateTime)row["TransactionDate"],
                    (int)row["ProcessedByUserID"],
                    (bool)row["IsScheduled"]
                );

                transactions.Add(transaction);
            }

            return transactions;
        }

        private static enTransactionType _parseTransactionType(string typeString)
        {
            if (Enum.TryParse<enTransactionType>(typeString, out enTransactionType type))
                return type;

            if (typeString.Contains("Transfer"))
                return enTransactionType.Transfer_In;

            return enTransactionType.Scheduled;
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

            return new clsTransactionLog(dto.TransactionID, type, fromAccount, toAccount,
                dto.Amount, dto.Description, dto.TransactionDate, dto.ProcessedByUserID, dto.IsScheduled);
        }
    }
}
