using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    public class clsTransactions : ITransactions
    {
        private static bool _returnAccountAndValidity(clsAccounts accountToCheck) => accountToCheck != null && accountToCheck.Status == clsAccounts.enStatus.Active;

        private static void _validateWithdrawals(clsAccounts accountToWithdraw, decimal amount)
        {
            if (accountToWithdraw == null || accountToWithdraw.Status != clsAccounts.enStatus.Active)
                throw new ArgumentException("Invalid account.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (accountToWithdraw.Balance - amount < accountToWithdraw.MinimumBalance)
                throw new ArgumentException("Insufficient funds to maintain minimum balance.");

            if (clsConfigurations.GetConfigValue(clsConfigurations.enConfigKey.LargeWithdrawalThreshold).Value < amount)
            {
                // thought the win service raise a Fraud Flag to the database so the manager or admin can manage it later, but for now I will just throw an exception to prevent the transaction from happening
                throw new ArgumentException("Withdrawal amount exceeds the large withdrawal threshold. Transaction flagged for review.");
            }
        }

        public static bool Deposit(int accountID, decimal amount, string description, int performedByUserID)
        {
            clsAccounts account = clsAccounts.Find(accountID);

            if (!_returnAccountAndValidity(account))
                throw new ArgumentException("Invalid account.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if(clsTransactions_DAL.Deposit(accountID, amount, description, performedByUserID))
            {
                account.Balance += amount; 
                return true;
            }

            return false;
        }

        public static bool Withdraw(int accountID, decimal amount, string description, int performedByUserID)
        {
            clsAccounts account = clsAccounts.Find(accountID);
            _validateWithdrawals(account, amount);
            
            if(clsTransactions_DAL.Withdraw(accountID, amount, description, performedByUserID))
            {
                account.Balance -= amount; 
                return true;
            }

            return false;
        }

        public static bool Transfer(int fromAccountID, int toAccountID, decimal amount, string description, int performedByUserID)
        {
            clsAccounts toAccount = clsAccounts.Find(toAccountID);

            if (!_returnAccountAndValidity(toAccount))
                throw new ArgumentException("Invalid destination account.");

            clsAccounts fromAccount = clsAccounts.Find(fromAccountID);
            _validateWithdrawals(fromAccount, amount); 

            if(clsTransactions_DAL.Transfer(fromAccountID, toAccountID, amount, description, performedByUserID))
            {
                fromAccount.Balance -= amount;
                toAccount.Balance += amount;
                return true;
            }

            return false;
        }

        public static bool ScheduleTransfer(int fromAccountID, int toAccountID, decimal amount, string description, DateTime scheduledDate, int performedByUserID)
        {
            // For scheduling transfers, through the win service.
            throw new NotImplementedException();
        }

        bool ITransactions.Deposit(int accountID, decimal amount, string description, int performedByUserID) => Deposit(accountID, amount, description, performedByUserID);

        bool ITransactions.Withdraw(int accountID, decimal amount, string description, int performedByUserID) => Withdraw(accountID, amount, description, performedByUserID);

        bool ITransactions.Transfer(int fromAccountID, int toAccountID, decimal amount, string description, int performedByUserID) => Transfer(fromAccountID, toAccountID, amount, description, performedByUserID);

        bool ITransactions.ScheduleTransfer(int fromAccountID, int toAccountID, decimal amount, string description, DateTime scheduledDate, int performedByUserID) => ScheduleTransfer(fromAccountID, toAccountID, amount, description, scheduledDate, performedByUserID);
    }
}
