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

        public static async Task<clsConfigurations> FindAsync(enConfigKey config)
        {
            clsConfigDto configDto = await clsConfigurations_DAL.GetConfigAsync((int)config);
            if (configDto != null)
            {
                var userAsync = await clsUsers.FindAsync(configDto.LastModifiedByUserID ?? -1);
                return new clsConfigurations(config, configDto.ConfigKey, configDto.ConfigValue, configDto.Description, 
                    configDto.LastModifiedDate ?? DateTime.MinValue, userAsync);
            }

            return null;
        }

        /// <summary>
        /// Use try and catch when calling this method to handle any exceptions that may occur during the update process.
        /// </summary>
        /// <returns>True if the configuration was successfully updated; otherwise, false.</returns>
        /// <exception cref="Exception">Thrown when Config, ConfigValue, or ModifiedByUser is not set.</exception>
        public async Task<bool> UpdateAsync()
        {
            if (Config == null || ConfigValue == null || clsGlobal.ActiveUser.UserID == null)
                throw new Exception("Config, ConfigValue, and ModifiedByUser must be set before updating.");

            if(await clsConfigurations_DAL.UpdateSystemConfigAsync(clsGlobal.ActiveUser.UserID.Value, ConfigKey, ConfigValue.ToString(), Description))
            {
                _configCache = await clsConfigurations_DAL.GetAllConfigAsync();
                return true;
            }

            return false;
        }

        private static Dictionary<string, int> _configCache = new Dictionary<string, int>();
        private static readonly Dictionary<enConfigKey, int> _defaultConfigValues = new Dictionary<enConfigKey, int>
        {
            { enConfigKey.LargeWithdrawalThreshold, 10000 },
            { enConfigKey.MaxLoginAttempts, 5 },
            { enConfigKey.MaxScheduledTransferRetries, 3 },
            { enConfigKey.RapidTransactionMaxCount, 5 },
            { enConfigKey.RapidTransactionWindowMinutes, 10 },
            { enConfigKey.ScheduledTransferCheckIntervalSeconds, 60 }
        };

        public static async Task<int?> GetConfigValueAsync(enConfigKey config)
        {
            if (_configCache.Count == 0)
                _configCache = await clsConfigurations_DAL.GetAllConfigAsync();

            if (_configCache.TryGetValue(config.ToString(), out int configValue))
                return configValue;

            return _defaultConfigValues.TryGetValue(config, out int defaultValue) ? defaultValue : (int?)null;
        }

        public static async Task<bool> ResetToDefaultAsync()
        {
            if (await clsConfigurations_DAL.ResetToDefaultAsync(clsGlobal.ActiveUser.UserID))
            {
                _configCache = await clsConfigurations_DAL.GetAllConfigAsync();
                return true;
            }

            return false;
        }
    }
}
