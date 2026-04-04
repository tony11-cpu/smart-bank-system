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
    public class clsConfigurations_DAL
    {
        public static Dictionary<string, int> GetAllConfig()
        {
            Dictionary<string, int> config = new Dictionary<string, int>();

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetAllConfig", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
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

        public static bool GetConfig(int configID, ref string configKey, ref int? configValue,
                                       ref string description, ref DateTime? lastModifiedDate, ref int? lastModifiedByUserID)
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
                    SqlParameter LastModifiedDate = new SqlParameter("@LastModifiedDate", SqlDbType.Date) { Direction = ParameterDirection.Output };
                    SqlParameter LastModifiedByUserID = new SqlParameter("@LastModifiedByUserID", SqlDbType.Int) { Direction = ParameterDirection.Output };

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    configKey = ConfigKey.Value.ToString();
                    configValue = Convert.ToInt32(ConfigValue.Value);
                    description = Description.Value.ToString();
                    lastModifiedDate = Convert.ToDateTime(LastModifiedDate.Value);
                    lastModifiedByUserID = Convert.ToInt32(LastModifiedByUserID.Value);

                    return true;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static bool UpdateSystemConfig(int adminUserID, string configKey, string configValue,
                                              string description, DateTime? lastModifiedDate,
                                              int? lastModifiedByUserID)
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
                    cmd.Parameters.AddWithValue("@LastModifiedDate", lastModifiedDate.HasValue ? (object)lastModifiedDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastModifiedByUserID", lastModifiedByUserID.HasValue ? (object)lastModifiedByUserID.Value : DBNull.Value);
                    SqlParameter pIsUpdated = new SqlParameter("@IsUpdated", SqlDbType.Bit) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(pIsUpdated);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return pIsUpdated.Value != DBNull.Value && Convert.ToBoolean(pIsUpdated.Value);
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                throw;
            }
        }
    }
}
