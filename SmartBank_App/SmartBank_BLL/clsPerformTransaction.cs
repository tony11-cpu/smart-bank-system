using SmartBank;
using SmartBank_BLL;
using SmartBack_DAL;
using System;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    internal class clsPerformTransaction : ITransactions
    {
        private static async Task<bool> _isManagerOrAdminAsync(int performedByUserID)
        {
            clsUsers performingUser = await clsUsers.FindAsync(performedByUserID);
            return performingUser?.Permissions != null &&
                (performingUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Manager ||
                 performingUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin);
        }

        private static async Task<clsAccounts> _validateAccountAsync(clsAccounts account, string accountType, string action, int performedByUserID, bool allowFrozenForPrivilegedUsers = false)
        {
            if (account == null)
                throw new ArgumentException($"{accountType} account not found.");

            if (account.Status == clsAccounts.enStatus.Active)
                return account;

            if (allowFrozenForPrivilegedUsers && account.Status == clsAccounts.enStatus.Frozen && await _isManagerOrAdminAsync(performedByUserID))
                return account;

            throw new ArgumentException($"{accountType} account is {account.Status}. Only Active accounts can {action}.");
        }

        private static async Task _validateWithdrawal(clsAccounts account, decimal amount, int performedByUserID)
        {
            if (account.Balance - amount < account.MinimumBalance)
                throw new ArgumentException("Insufficient funds to maintain minimum balance.");
        }

        public static async Task<bool> DepositAsync(int accountID, decimal amount, string description, int performedByUserID)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            clsAccounts account = await _validateAccountAsync(await clsAccounts.FindAsync(accountID), "Source", "receive deposits", performedByUserID, true);
            return await clsTransactions_DAL.DepositAsync(accountID, amount, description, performedByUserID);
        }

        public static async Task<bool> WithdrawAsync(int? accountID, decimal amount, string description, int performedByUserID, bool dynamic = true)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            await _validateWithdrawal(await _validateAccountAsync(await clsAccounts.FindAsync(accountID ?? throw new ArgumentException("Account ID cannot be null.")),
                "Source", "process withdrawals", performedByUserID, true), amount, performedByUserID);

            if (await clsTransactions_DAL.WithdrawAsync(accountID.Value, amount, description, performedByUserID))
            {
                await clsFraudDetectionService.EvaluateDebitTransactionAsync(accountID.Value, amount, DateTime.Now);
                return true;
            }

            return false;
        }

        public static async Task<bool> TransferAsync(int? fromAccountID, int? toAccountID, decimal amount, string description, int performedByUserID)
        {
            if (!fromAccountID.HasValue || !toAccountID.HasValue)
                throw new ArgumentException("Either fromAccountID or toAccountID cannot be null.");

            if (fromAccountID.Value == toAccountID.Value)
                throw new ArgumentException("Source and destination accounts cannot be the same.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");
            
            clsAccounts fromAccount = await _validateAccountAsync(await clsAccounts.FindAsync(fromAccountID.Value), "Source", "initiate transfers", performedByUserID, true);
            clsAccounts toAccount = await _validateAccountAsync(await clsAccounts.FindAsync(toAccountID.Value), "Destination", "receive transfers", performedByUserID);

            await _validateWithdrawal(fromAccount, amount, performedByUserID);

            if (await clsTransactions_DAL.TransferAsync(fromAccountID.Value, toAccountID.Value, amount, description, performedByUserID))
            {
                await clsFraudDetectionService.EvaluateDebitTransactionAsync(fromAccountID.Value, amount, DateTime.Now);
                return true;
            }

            return false;
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

            clsAccounts fromAccount = await _validateAccountAsync(await clsAccounts.FindAsync(fromAccountID.Value), "Source", "schedule transfers", performedByUserID, true);
            clsAccounts toAccount = await _validateAccountAsync(await clsAccounts.FindAsync(toAccountID.Value), "Destination", "receive transfers", performedByUserID);

            await _validateWithdrawal(fromAccount, amount, performedByUserID);
            return await clsTransactions_DAL.ScheduleTransferAsync(fromAccountID.Value, toAccountID.Value, amount, description, scheduledDate, performedByUserID);
        }

        async Task<bool> ITransactions.Deposit(int accountID, decimal amount, string description, int performedByUserID) => await DepositAsync(accountID, amount, description, performedByUserID);
        async Task<bool> ITransactions.Withdraw(int accountID, decimal amount, string description, int performedByUserID) => await WithdrawAsync(accountID, amount, description, performedByUserID);
        async Task<bool> ITransactions.Transfer(int fromAccountID, int toAccountID, decimal amount, string description, int performedByUserID) => await TransferAsync(fromAccountID, toAccountID, amount, description, performedByUserID);
        async Task<bool> ITransactions.ScheduleTransfer(int fromAccountID, int toAccountID, decimal amount, string description, DateTime scheduledDate, int performedByUserID) => await ScheduleTransferAsync(fromAccountID, toAccountID, amount, description, scheduledDate, performedByUserID);
    }
}
