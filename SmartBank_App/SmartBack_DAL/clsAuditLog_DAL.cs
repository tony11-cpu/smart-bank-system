using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartBack_DAL
{
    public class clsAuditLogDto
    {
        public int AuditID { get; set; }
        public int? UserID { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public string EntityType { get; set; }
        public int? EntityID { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Timestamp { get; set; }
        public string Notes { get; set; }

        public clsAuditLogDto(int auditID, int? userID, string username, string action, string entityType, int? entityID,
                              string oldValue, string newValue, DateTime timestamp, string notes)
        {
            AuditID = auditID;
            UserID = userID;
            Username = username;
            Action = action;
            EntityType = entityType;
            EntityID = entityID;
            OldValue = oldValue;
            NewValue = newValue;
            Timestamp = timestamp;
            Notes = notes;
        }
    }

    public static class clsAuditLog_DAL
    {
        public static async Task<clsAuditLogDto> GetAuditLogByAuditIDAsync(int auditID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetAuditLogByAuditID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AuditID", auditID);

                    SqlParameter pUserID = new SqlParameter("@UserID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter pUsername = new SqlParameter("@Username", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                    SqlParameter pAction = new SqlParameter("@Action", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                    SqlParameter pEntityType = new SqlParameter("@EntityType", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
                    SqlParameter pEntityID = new SqlParameter("@EntityID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter pOldValue = new SqlParameter("@OldValue", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };
                    SqlParameter pNewValue = new SqlParameter("@NewValue", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output };
                    SqlParameter pTimestamp = new SqlParameter("@Timestamp", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
                    SqlParameter pNotes = new SqlParameter("@Notes", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(pUserID);
                    cmd.Parameters.Add(pUsername);
                    cmd.Parameters.Add(pAction);
                    cmd.Parameters.Add(pEntityType);
                    cmd.Parameters.Add(pEntityID);
                    cmd.Parameters.Add(pOldValue);
                    cmd.Parameters.Add(pNewValue);
                    cmd.Parameters.Add(pTimestamp);
                    cmd.Parameters.Add(pNotes);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    if (pTimestamp.Value == DBNull.Value)
                        return null;

                    return new clsAuditLogDto(auditID,
                                              pUserID.Value == DBNull.Value ? (int?)null : Convert.ToInt32(pUserID.Value),
                                              pUsername.Value == DBNull.Value ? null : pUsername.Value.ToString(),
                                              pAction.Value == DBNull.Value ? null : pAction.Value.ToString(),
                                              pEntityType.Value == DBNull.Value ? null : pEntityType.Value.ToString(),
                                              pEntityID.Value == DBNull.Value ? (int?)null : Convert.ToInt32(pEntityID.Value),
                                              pOldValue.Value == DBNull.Value ? null : pOldValue.Value.ToString(),
                                              pNewValue.Value == DBNull.Value ? null : pNewValue.Value.ToString(),
                                              Convert.ToDateTime(pTimestamp.Value),
                                              pNotes.Value == DBNull.Value ? null : pNotes.Value.ToString());
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return null;
        }

        public static async Task<DataTable> GetAuditLogListAsync()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetAuditLogList", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        dt.Load(reader);

                    return dt;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return null;
        }
    }
}
