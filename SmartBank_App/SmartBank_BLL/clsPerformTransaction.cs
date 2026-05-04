using SmartBank;
using SmartBank_BLL;
using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    internal class clsPerformTransaction : ITransactions
    {
        private static bool _returnAccountAndValidity(clsAccounts accountToCheck) => accountToCheck != null && accountToCheck.Status == clsAccounts.enStatus.Active;

        // need further functionality for the scheduled transfers since the win service is not implemented yet.
        private static async Task _validateWithdrawals(clsAccounts accountToWithdraw, decimal amount, int performedByUserID)
        {
            if (accountToWithdraw == null || accountToWithdraw.Status != clsAccounts.enStatus.Active)
                throw new ArgumentException("Invalid account.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            clsUsers performingUser = await clsUsers.FindAsync(performedByUserID);
            bool isManagerOrAdmin = performingUser?.Permissions != null && 
                (performingUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Manager ||
                 performingUser.Permissions.PermissionPresenter == clsPermissions.enPermissionPresenter.Admin);

            if (!isManagerOrAdmin && accountToWithdraw.Balance - amount < accountToWithdraw.MinimumBalance)
                throw new ArgumentException("Insufficient funds to maintain minimum balance.");

            if (!isManagerOrAdmin && (await clsConfigurations.GetConfigValueAsync(clsConfigurations.enConfigKey.LargeWithdrawalThreshold)).Value < amount)
            {
                throw new ArgumentException("Withdrawal amount exceeds the large withdrawal threshold. Transaction flagged for review.");
            }
        }

        public static async Task<bool> DepositAsync(int accountID, decimal amount, string description, int performedByUserID)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (!_returnAccountAndValidity(await clsAccounts.FindAsync(accountID)))
                throw new ArgumentException("Invalid account.");

            return await clsTransactions_DAL.DepositAsync(accountID, amount, description, performedByUserID);
        }

        public static async Task<bool> WithdrawAsync(int? accountID, decimal amount, string description, int performedByUserID, bool dynamic = true)
        {
            await _validateWithdrawals(await clsAccounts.FindAsync(accountID ?? throw new ArgumentException("Account ID cannot be null.")), amount, performedByUserID);
            return await clsTransactions_DAL.WithdrawAsync(accountID.Value, amount, description, performedByUserID);
        }

        public static async Task<bool> TransferAsync(int? fromAccountID, int? toAccountID, decimal amount, string description, int performedByUserID)
        {
            if(!fromAccountID.HasValue || !toAccountID.HasValue)
                throw new ArgumentException("Either fromAccountID or toAccountID cannot be null.");

            if(amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            clsAccounts toAccount = await clsAccounts.FindAsync(toAccountID.Value);

            if (!_returnAccountAndValidity(toAccount))
                throw new ArgumentException("Invalid destination account.");

            clsAccounts fromAccount = await clsAccounts.FindAsync(fromAccountID.Value);
            await _validateWithdrawals(fromAccount, amount, performedByUserID);

            return await clsTransactions_DAL.TransferAsync(fromAccountID.Value, toAccountID.Value, amount, description, performedByUserID);
        }

        // need further functionality for the scheduled transfers since the win service is not implemented yet.
        public static async Task<bool> ScheduleTransferAsync(int? fromAccountID, int? toAccountID, decimal amount, string description, DateTime scheduledDate, int performedByUserID)
        {
            // For scheduling transfers, through the win service.
            throw new NotImplementedException();
        }


        async Task<bool> ITransactions.Deposit(int accountID, decimal amount, string description, int performedByUserID) => await DepositAsync(accountID, amount, description, performedByUserID);

        async Task<bool> ITransactions.Withdraw(int accountID, decimal amount, string description, int performedByUserID) => await WithdrawAsync(accountID, amount, description, performedByUserID);

        async Task<bool> ITransactions.Transfer(int fromAccountID, int toAccountID, decimal amount, string description, int performedByUserID) => await TransferAsync(fromAccountID, toAccountID, amount, description, performedByUserID);
        async Task<bool> ITransactions.ScheduleTransfer(int fromAccountID, int toAccountID, decimal amount, string description, DateTime scheduledDate, int performedByUserID) => await ScheduleTransferAsync(fromAccountID, toAccountID, amount, description, scheduledDate, performedByUserID);
    }
}
