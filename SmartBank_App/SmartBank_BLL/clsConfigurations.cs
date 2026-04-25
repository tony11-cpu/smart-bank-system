using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SmartBank;
using SmartBack_DAL;

namespace SmartBank_BLL
{
    public class clsConfigurations
    {
        public clsConfigurations(enConfigKey config, string configKey, int configValue,
                                 string description, DateTime lastModifiedDate, clsUsers lastModifiedByUser)
        {
            Config = config;
            ConfigKey = configKey;
            ConfigValue = configValue;
            Description = description;
            LastModifiedDate = lastModifiedDate;
            LastModifiedByUser = lastModifiedByUser;
        }

        public enum enConfigKey
        {
            LargeWithdrawalThreshold = 1,
            MaxLoginAttempts = 2,
            MaxScheduledTransferRetries = 3,
            RapidTransactionMaxCount = 4,
            RapidTransactionWindowMinutes = 5,
            ScheduledTransferCheckIntervalSeconds = 6
        }

        public enConfigKey? Config { get; set; }

        public string ConfigKey { get; set; } = null;

        public int? ConfigValue { get; set; } = null;

        public string Description { get; set; } = null;

        public DateTime? LastModifiedDate { get; set; } = null;

        public clsUsers LastModifiedByUser { get; set; } = null;

        public static async Task<clsConfigurations> Find(enConfigKey config)
        {
            string configKey = null;
            int? configValue = null;
            string description = null;
            DateTime? lastModifiedDate = null;
            int? lastModifiedByUserID = null;

            if (clsConfigurations_DAL.GetConfig((int)config, ref configKey, ref configValue, ref description, ref lastModifiedDate, ref lastModifiedByUserID))
            {
                var userAsync = await clsUsers.FindAsync(lastModifiedByUserID ?? -1);
                return new clsConfigurations(config, configKey, configValue ?? -1, description, lastModifiedDate ?? DateTime.MinValue, userAsync);
            }

            return null;
        }

        /// <summary>
        /// Use try and catch when calling this method to handle any exceptions that may occur during the update process.
        /// </summary>
        /// <returns>True if the configuration was successfully updated; otherwise, false.</returns>
        /// <exception cref="Exception">Thrown when Config, ConfigValue, or ModifiedByUser is not set.</exception>
        public bool Update()
        {
            if (Config == null || ConfigValue == null || clsGlobal.ActiveUser.UserID == null)
                throw new Exception("Config, ConfigValue, and ModifiedByUser must be set before updating.");

            if(clsConfigurations_DAL.UpdateSystemConfig(clsGlobal.ActiveUser.UserID.Value, ConfigKey, ConfigValue.ToString(), Description))
            {
                _configCache = clsConfigurations_DAL.GetAllConfig();
                return true;
            }

            return false;
        }

        private static Dictionary<string, int> _configCache = new Dictionary<string, int>();

        public static int? GetConfigValue(enConfigKey Config)
        {
            if (_configCache.Count == 0)
            {
                _configCache = clsConfigurations_DAL.GetAllConfig();
            }

            return _configCache.Count == 0 ? (int?)null : _configCache[Config.ToString()];
        }

        public static bool ResetToDefault()
        {
            if (clsConfigurations_DAL.ResetToDefault(clsGlobal.ActiveUser.UserID))
            {
                _configCache = clsConfigurations_DAL.GetAllConfig();
                return true;
            }

            return false;
        }
    }
}
