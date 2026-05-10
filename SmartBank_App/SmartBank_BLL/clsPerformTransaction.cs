using SmartBank;
using SmartBank_BLL;
using SmartBack_DAL;
using System;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    internal class clsPerformTransaction : ITransactions
    {
        private static clsAccounts _validateAccount(clsAccounts account, string accountType, string action)
        {
            if (account == null)
                throw new ArgumentException($"{accountType} account not found.");
            
            if (account.Status != clsAccounts.enStatus.Active)
                throw new ArgumentException($"{accountType} account is {account.Status}. Only Active accounts can {action}.");

            return account;
        }

        private static async Task _validateWithdrawal(clsAccounts account, decimal amount, int performedByUserID)
        {
            clsUsers performingUser = await clsUsers.FindAsync(performedByUserID);
            bool isManagerOrAdmin = performingUser?.Permissions != null && 
                (performingUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Manager ||
                 performingUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin);

            if (!isManagerOrAdmin && account.Balance - amount < account.MinimumBalance)
                throw new ArgumentException("Insufficient funds to maintain minimum balance.");

            if (!isManagerOrAdmin && (await clsConfigurations.GetConfigValueAsync(clsConfigurations.enConfigKey.LargeWithdrawalThreshold)).Value < amount)
                throw new ArgumentException("Withdrawal amount exceeds the large withdrawal threshold. Transaction flagged for review.");
        }

        public static async Task<bool> DepositAsync(int accountID, decimal amount, string description, int performedByUserID)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            clsAccounts account = _validateAccount(await clsAccounts.FindAsync(accountID), "Source", "receive deposits");
            return await clsTransactions_DAL.DepositAsync(accountID, amount, description, performedByUserID);
        }

        public static async Task<bool> WithdrawAsync(int? accountID, decimal amount, string description, int performedByUserID, bool dynamic = true)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");
            
            clsAccounts account = _validateAccount(await clsAccounts.FindAsync(accountID ?? throw new ArgumentException("Account ID cannot be null.")), "Source", "process withdrawals");
            await _validateWithdrawal(account, amount, performedByUserID);
            return await clsTransactions_DAL.WithdrawAsync(accountID.Value, amount, description, performedByUserID);
        }

        public static async Task<bool> TransferAsync(int? fromAccountID, int? toAccountID, decimal amount, string description, int performedByUserID)
        {
            if (!fromAccountID.HasValue || !toAccountID.HasValue)
                throw new ArgumentException("Either fromAccountID or toAccountID cannot be null.");

            if (fromAccountID.Value == toAccountID.Value)
                throw new ArgumentException("Source and destination accounts cannot be the same.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");
            
            clsAccounts fromAccount = _validateAccount(await clsAccounts.FindAsync(fromAccountID.Value), "Source", "initiate transfers");
            clsAccounts toAccount = _validateAccount(await clsAccounts.FindAsync(toAccountID.Value), "Destination", "receive transfers");

            await _validateWithdrawal(fromAccount, amount, performedByUserID);
            return await clsTransactions_DAL.TransferAsync(fromAccountID.Value, toAccountID.Value, amount, description, performedByUserID);
        }

        public static async Task<bool> ScheduleTransferAsync(int? fromAccountID, int? toAccountID, decimal amount, string description, DateTime scheduledDate, int performedByUserID)
        {
            if (!fromAccountID.HasValue || !toAccountID.HasValue)
                throw new ArgumentException("From and To account IDs are required.");

            if (fromAccountID.Value == toAccountID.Value)
                throw new ArgumentException("Source and destination accounts cannot be the same.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (scheduledDate <= DateTime.Now)
                throw new ArgumentException("Scheduled date must be in the future.");

            clsAccounts fromAccount = _validateAccount(await clsAccounts.FindAsync(fromAccountID.Value), "Source", "schedule transfers");
            clsAccounts toAccount = _validateAccount(await clsAccounts.FindAsync(toAccountID.Value), "Destination", "receive transfers");

            return await clsTransactions_DAL.ScheduleTransferAsync(fromAccountID.Value, toAccountID.Value, amount, description, scheduledDate, performedByUserID);
        }

        async Task<bool> ITransactions.Deposit(int accountID, decimal amount, string description, int performedByUserID) => await DepositAsync(accountID, amount, description, performedByUserID);
        async Task<bool> ITransactions.Withdraw(int accountID, decimal amount, string description, int performedByUserID) => await WithdrawAsync(accountID, amount, description, performedByUserID);
        async Task<bool> ITransactions.Transfer(int fromAccountID, int toAccountID, decimal amount, string description, int performedByUserID) => await TransferAsync(fromAccountID, toAccountID, amount, description, performedByUserID);
        async Task<bool> ITransactions.ScheduleTransfer(int fromAccountID, int toAccountID, decimal amount, string description, DateTime scheduledDate, int performedByUserID) => await ScheduleTransferAsync(fromAccountID, toAccountID, amount, description, scheduledDate, performedByUserID);
    }
}
