using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBack_DAL
{
    public class clsConfigDto
    {
        public int ConfigID { get; set; }
        public string ConfigKey { get; set; }
        public int ConfigValue { get; set; }
        public string Description { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedByUserID { get; set; }

        public clsConfigDto(int configID, string configKey, int configValue, string description, DateTime? lastModifiedDate, int? lastModifiedByUserID)
        {
            ConfigID = configID;
            ConfigKey = configKey;
            ConfigValue = configValue;
            Description = description;
            LastModifiedDate = lastModifiedDate;
            LastModifiedByUserID = lastModifiedByUserID;
        }
    }

    public static class clsConfigurations_DAL
    {
        public static async Task<Dictionary<string, int>> GetAllConfigAsync()
        {
            Dictionary<string, int> config = new Dictionary<string, int>();

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetAllConfig", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            config[reader["ConfigKey"].ToString()] = Convert.ToInt32(reader["ConfigValue"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return config;
        }

        public static async Task<clsConfigDto> GetConfigAsync(int configID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetConfigByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ConfigID", configID);

                    SqlParameter ConfigKey = new SqlParameter("@ConfigKey", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
                    SqlParameter ConfigValue = new SqlParameter("@ConfigValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter Description = new SqlParameter("@Description", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output };
                    SqlParameter LastModifiedDate = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
                    SqlParameter LastModifiedByUserID = new SqlParameter("@LastModifiedByUserID", SqlDbType.Int) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(ConfigKey);
                    cmd.Parameters.Add(ConfigValue);
                    cmd.Parameters.Add(Description);
                    cmd.Parameters.Add(LastModifiedDate);
                    cmd.Parameters.Add(LastModifiedByUserID);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    if (ConfigKey.Value == DBNull.Value)
                        return null;

                    return new clsConfigDto(configID,
                        ConfigKey.Value.ToString(),
                        ConfigValue.Value == DBNull.Value ? 0 : Convert.ToInt32(ConfigValue.Value),
                        Description.Value == DBNull.Value ? null : Description.Value.ToString(),
                        LastModifiedDate.Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(LastModifiedDate.Value),
                        LastModifiedByUserID.Value == DBNull.Value ? (int?)null : Convert.ToInt32(LastModifiedByUserID.Value));
                }
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return null;
        }

        public static async Task<bool> UpdateSystemConfigAsync(int adminUserID, string configKey, string configValue, string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateSystemConfig", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdminUserID", adminUserID);
                    cmd.Parameters.AddWithValue("@ConfigKey", configKey);
                    cmd.Parameters.AddWithValue("@ConfigValue", configValue);
                    cmd.Parameters.AddWithValue("@Description", description);

                    SqlParameter pIsUpdated = new SqlParameter("@IsUpdated", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(pIsUpdated);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return pIsUpdated.Value != DBNull.Value && Convert.ToBoolean(pIsUpdated.Value);
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                return false;
            }
        }

        public static async Task<bool> ResetToDefaultAsync(int? adminUserID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_ResetConfigToDefault", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdminUserID", adminUserID.HasValue ? (object)adminUserID.Value : DBNull.Value);

                    SqlParameter isResetParam = new SqlParameter("@IsReset", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(isResetParam);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return (bool)isResetParam.Value;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }
    }
}
