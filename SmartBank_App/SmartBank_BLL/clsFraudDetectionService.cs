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
        private const string _largeWithdrawalFlagType = "LARGE_WITHDRAWAL";
        private const string _rapidTransactionsFlagType = "RAPID_TRANSACTIONS";
        private const int _systemUserID = 1;

        private static async Task<bool> _isTransactionAlreadyFlaggedAsync(int accountID, string flagType, int transactionID) =>
            (await clsFraudFlags.GetFraudFlagsByAccountIDAsync(accountID)).Any(n => n.FlagType == flagType && (n.Details ?? string.Empty).Contains($"[TXN:{transactionID}]"));

        private static async Task _createFraudFlagAsync(int accountID, string flagType, string details, int? transactionID = null)
        {
            if (transactionID.HasValue && await _isTransactionAlreadyFlaggedAsync(accountID, flagType, transactionID.Value))
                return;

            if ((await clsFraudFlags.CreateAsync(clsGlobal.ActiveUser?.UserID ?? _systemUserID, accountID, flagType, details)) > 0)
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
                await _createFraudFlagAsync(accountID, _largeWithdrawalFlagType, 
                    $"Automatic detection: transaction amount {amount:C} exceeded configured threshold {largeWithdrawalThreshold:C}." +
                    $"{(transactionID.HasValue ? $" [TXN:{transactionID.Value}]" : string.Empty)}", transactionID);

            int postedDebitCount = await clsTransactions_DAL.GetPostedDebitCountByAccountWithinWindowAsync(accountID, transactionDate.AddMinutes(-rapidTransactionWindowMinutes), transactionDate);
            if (postedDebitCount >= rapidTransactionMaxCount + 1)
                await _createFraudFlagAsync(accountID, _rapidTransactionsFlagType,
                    $"Automatic detection: {postedDebitCount} debit transactions within {rapidTransactionWindowMinutes} minutes (max allowed {rapidTransactionMaxCount})." +
                    $"{(transactionID.HasValue ? $" [TXN:{transactionID.Value}]" : string.Empty)}", transactionID);
        }

        public static async Task EvaluateScheduledDebitTransactionsAsync(DataTable processedScheduledDebits)
        {
            if (processedScheduledDebits == null || processedScheduledDebits.Rows.Count == 0)
                return;

            foreach (DataRow row in processedScheduledDebits.Rows)
                await EvaluateDebitTransactionAsync((int)row["AccountID"], (decimal)row["Amount"], (DateTime)row["TransactionDate"], (int)row["TransactionID"]);
        }
    }
}
