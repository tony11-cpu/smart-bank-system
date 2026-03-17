using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SmartBank_BLL
{
    public class clsConfigurations
    {
        private static bool _isLoaded = false;
        private static Dictionary<string, string> _sysConfigurations;
        private static int _fetchConfigValue(string key, int defaultValue)
        {
            if (!_isLoaded)
            {
                _sysConfigurations = SmartBack_DAL.clsConfigurations_DAL.GetAllConfig();
                _isLoaded = true;
            }

            return int.TryParse(_sysConfigurations[key], out int result) ? result : defaultValue;
        }

        public static int MaxLoginAttempts => _fetchConfigValue("MaxLoginAttempts", 5);
        public static int LargeWithdrawalThreshold => _fetchConfigValue("LargeWithdrawalThreshold", 1000);
        public static int MaxScheduledTransferRetries => _fetchConfigValue("MaxScheduledTransferRetries", 3);
        public static int RapidTransactionMaxCount => _fetchConfigValue("RapidTransactionMaxCount", 5);
        public static int RapidTransactionWindowMinutes => _fetchConfigValue("RapidTransactionWindowMinutes", 10);
        public static int ScheduledTransferCheckIntervalSeconds => _fetchConfigValue("ScheduledTransferCheckIntervalSeconds", 60);
        public static string EncryptionKey => ConfigurationManager.AppSettings["EncryptionKey"].ToString();
    }
}
