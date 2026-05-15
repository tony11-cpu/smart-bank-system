using SmartBack_DAL;
using SmartBank;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    public static class clsFraudDetectionService
    {
        private const string _largeWithdrawalFlagType = "Large Withdrawal";
        private const string _rapidTransactionsFlagType = "Rapid Transactions";
        private const int _systemUserID = 1;

        private static int _getUserInActionID() => clsGlobal.ActiveUser?.UserID ?? _systemUserID;

        private static async Task<bool> _isTransactionAlreadyFlaggedAsync(int accountID, string flagType, int transactionID)
        {
            string transactionToken = $"[TXN:{transactionID}]";
            List<clsFraudFlags> accountFlags = await clsFraudFlags.GetFraudFlagsByAccountIDAsync(accountID);
            return accountFlags.Any(n => n.FlagType == flagType && (n.Details ?? string.Empty).Contains(transactionToken));
        }

        private static async Task _createFraudFlagAsync(int accountID, string flagType, string details, int? transactionID = null)
        {
            if (transactionID.HasValue && await _isTransactionAlreadyFlaggedAsync(accountID, flagType, transactionID.Value))
                return;

            int newFlagID = await clsFraudFlags.CreateAsync(_getUserInActionID(), accountID, flagType, details);
            if (newFlagID > 0)
                clsGlobal.FireTransactionCompleted();
        }

        public static async Task EvaluateDebitTransactionAsync(int accountID, decimal amount, DateTime transactionDate, int? transactionID = null)
        {
            if (accountID <= 0 || amount <= 0)
                return;

            int largeWithdrawalThreshold = (await clsConfigurations.GetConfigValueAsync(clsConfigurations.enConfigKey.LargeWithdrawalThreshold)) ?? 10000;
            int rapidTransactionMaxCount = (await clsConfigurations.GetConfigValueAsync(clsConfigurations.enConfigKey.RapidTransactionMaxCount)) ?? 5;
            int rapidTransactionWindowMinutes = (await clsConfigurations.GetConfigValueAsync(clsConfigurations.enConfigKey.RapidTransactionWindowMinutes)) ?? 10;

            if (amount > largeWithdrawalThreshold)
            {
                string transactionToken = transactionID.HasValue ? $" [TXN:{transactionID.Value}]" : string.Empty;
                string details = $"Automatic detection: transaction amount {amount:C} exceeded configured threshold {largeWithdrawalThreshold:C}.{transactionToken}";
                await _createFraudFlagAsync(accountID, _largeWithdrawalFlagType, details, transactionID);
            }

            DateTime fromDate = transactionDate.AddMinutes(-rapidTransactionWindowMinutes);
            int postedDebitCount = await clsTransactions_DAL.GetPostedDebitCountByAccountWithinWindowAsync(accountID, fromDate, transactionDate);

            if (postedDebitCount == rapidTransactionMaxCount + 1)
            {
                string transactionToken = transactionID.HasValue ? $" [TXN:{transactionID.Value}]" : string.Empty;
                string details = $"Automatic detection: {postedDebitCount} debit transactions within {rapidTransactionWindowMinutes} minutes (max allowed {rapidTransactionMaxCount}).{transactionToken}";
                await _createFraudFlagAsync(accountID, _rapidTransactionsFlagType, details, transactionID);
            }
        }

        public static async Task EvaluateScheduledDebitTransactionsAsync(DataTable processedScheduledDebits)
        {
            if (processedScheduledDebits == null || processedScheduledDebits.Rows.Count == 0)
                return;

            foreach (DataRow row in processedScheduledDebits.Rows)
            {
                await EvaluateDebitTransactionAsync((int)row["AccountID"], (decimal)row["Amount"],
                    (DateTime)row["TransactionDate"], (int)row["TransactionID"]);
            }
        }
    }
}
