using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    internal interface ITransactions
    {
        Task<bool> Deposit(int accountID, decimal amount, string description, int performedByUserID);
        Task<bool> Withdraw(int accountID, decimal amount, string description, int performedByUserID);
        Task<bool> Transfer(int fromAccountID, int toAccountID, decimal amount, string description, int performedByUserID);
        Task<bool> ScheduleTransfer(int fromAccountID, int toAccountID, decimal amount, string description, DateTime scheduledDate, int performedByUserID);
    }
}
