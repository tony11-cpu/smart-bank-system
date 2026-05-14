using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    public class clsAuditLog
    {
        public int AuditID { get; private set; }
        public int? UserID { get; private set; }
        public string Username { get; private set; }
        public string Action { get; private set; }
        public string EntityType { get; private set; }
        public int? EntityID { get; private set; }
        public string OldValue { get; private set; }
        public string NewValue { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string Notes { get; private set; }

        public clsAuditLog(int auditID, int? userID, string username, string action, string entityType, int? entityID,
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

        public static async Task<clsAuditLog> FindAsync(int auditID)
        {
            clsAuditLogDto dto = await clsAuditLog_DAL.GetAuditLogByAuditIDAsync(auditID);
            if (dto == null)
                return null;

            return new clsAuditLog(dto.AuditID, dto.UserID, dto.Username, dto.Action, dto.EntityType, dto.EntityID,
                                   dto.OldValue, dto.NewValue, dto.Timestamp, dto.Notes);
        }

        public static async Task<List<clsAuditLog>> GetAllAuditLogsAsync()
        {
            DataTable dt = await clsAuditLog_DAL.GetAuditLogListAsync();
            if (dt == null || dt.Rows.Count == 0)
                return new List<clsAuditLog>();

            List<clsAuditLog> logs = new List<clsAuditLog>();
            foreach (DataRow row in dt.Rows)
            {
                logs.Add(new clsAuditLog(
                    Convert.ToInt32(row["AuditID"]),
                    row["UserID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["UserID"]),
                    row["Username"] == DBNull.Value ? null : row["Username"].ToString(),
                    row["Action"] == DBNull.Value ? null : row["Action"].ToString(),
                    row["EntityType"] == DBNull.Value ? null : row["EntityType"].ToString(),
                    row["EntityID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["EntityID"]),
                    row["OldValue"] == DBNull.Value ? null : row["OldValue"].ToString(),
                    row["NewValue"] == DBNull.Value ? null : row["NewValue"].ToString(),
                    Convert.ToDateTime(row["Timestamp"]),
                    row["Notes"] == DBNull.Value ? null : row["Notes"].ToString()
                ));
            }

            return logs;
        }
    }
}
