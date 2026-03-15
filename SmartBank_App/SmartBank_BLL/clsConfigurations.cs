using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    public class clsConfigurations
    {
        private static Dictionary<string, string> _sysConfigurations = SmartBack_DAL.clsConfigurations.GetAllConfig();

        public static int MaxLoginAttempts => 
            int.TryParse(_sysConfigurations["MaxLoginAttempts"], out int result) ? result : 5;
        public static int LargeWithdrawalThreshold =>
            int.TryParse(_sysConfigurations["LargeWithdrawalThreshold"], out int result) ? result : 10000;
        public static int MaxScheduledTransferRetries => 
            int.TryParse(_sysConfigurations["MaxScheduledTransferRetries"], out int result) ? result : 3;
        public static int RapidTransactionMaxCount => 
            int.TryParse(_sysConfigurations["RapidTransactionMaxCount"], out int result) ? result : 5;
        public static int RapidTransactionWindowMinutes => 
            int.TryParse(_sysConfigurations["RapidTransactionWindowMinutes"], out int result) ? result : 10;
        public static int ScheduledTransferCheckIntervalSeconds => 
            int.TryParse(_sysConfigurations["ScheduledTransferCheckIntervalSeconds"], out int result) ? result : 60;
    }
}
