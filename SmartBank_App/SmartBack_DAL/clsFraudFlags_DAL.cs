using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartBack_DAL
{
    public class clsFraudFlagDto
    {
        public int FlagID { get; set; }
        public int AccountID { get; set; }
        public string FlagType { get; set; }
        public DateTime FlaggedDate { get; set; }
        public string Details { get; set; }
        public bool IsResolved { get; set; }
        public int? ResolvedByUserID { get; set; }
        public DateTime? ResolvedDate { get; set; }

        public clsFraudFlagDto(int flagID, int accountID, string flagType, DateTime flaggedDate, string details,
                               bool isResolved, int? resolvedByUserID, DateTime? resolvedDate)
        {
            FlagID = flagID;
            AccountID = accountID;
            FlagType = flagType;
            FlaggedDate = flaggedDate;
            Details = details;
            IsResolved = isResolved;
            ResolvedByUserID = resolvedByUserID;
            ResolvedDate = resolvedDate;
        }
    }

    public static class clsFraudFlags_DAL
    {
        public static async Task<bool> IsFraudFlagExistByIDAsync(int flagID)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsFraudFlagExistsByID(@FlagID)", conn))
            {
                cmd.Parameters.AddWithValue("@FlagID", flagID);

                try
                {
                    await conn.OpenAsync();
                    return Convert.ToBoolean(await cmd.ExecuteScalarAsync());
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return false;
        }

        public static async Task<clsFraudFlagDto> GetFraudFlagByIDAsync(int flagID)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetFraudFlagByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FlagID", flagID);

                SqlParameter pAccountID = new SqlParameter("@AccountID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter pFlagType = new SqlParameter("@FlagType", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter pFlaggedDate = new SqlParameter("@FlaggedDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
                SqlParameter pDetails = new SqlParameter("@Details", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };
                SqlParameter pIsResolved = new SqlParameter("@IsResolved", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                SqlParameter pResolvedByUserID = new SqlParameter("@ResolvedByUserID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter pResolvedDate = new SqlParameter("@ResolvedDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };

                cmd.Parameters.Add(pAccountID);
                cmd.Parameters.Add(pFlagType);
                cmd.Parameters.Add(pFlaggedDate);
                cmd.Parameters.Add(pDetails);
                cmd.Parameters.Add(pIsResolved);
                cmd.Parameters.Add(pResolvedByUserID);
                cmd.Parameters.Add(pResolvedDate);

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    if (pAccountID.Value == DBNull.Value)
                        return null;

                    return new clsFraudFlagDto(
                        flagID,
                        (int)pAccountID.Value,
                        pFlagType.Value == DBNull.Value ? null : (string)pFlagType.Value,
                        (DateTime)pFlaggedDate.Value,
                        pDetails.Value == DBNull.Value ? null : (string)pDetails.Value,
                        (bool)pIsResolved.Value,
                        pResolvedByUserID.Value == DBNull.Value ? (int?)null : (int)pResolvedByUserID.Value,
                        pResolvedDate.Value == DBNull.Value ? (DateTime?)null : (DateTime)pResolvedDate.Value
                    );
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return null;
        }

        public static async Task<int> CreateFraudFlagAsync(int userInActionID, int accountID, string flagType, string details)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_CreateFraudFlag", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserInActionID", userInActionID);
                cmd.Parameters.AddWithValue("@AccountID", accountID);
                cmd.Parameters.AddWithValue("@FlagType", flagType);
                cmd.Parameters.AddWithValue("@Details", details);

                SqlParameter pNewFlagID = new SqlParameter("@NewFlagID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(pNewFlagID);

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return (int)pNewFlagID.Value;
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return -1;
        }

        public static async Task<bool> ResolveFraudFlagAsync(int userInActionID, int flagID)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ResolveFraudFlag", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserInActionID", userInActionID);
                cmd.Parameters.AddWithValue("@FlagID", flagID);

                SqlParameter pIsUpdated = new SqlParameter("@IsUpdated", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(pIsUpdated);

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return pIsUpdated.Value != DBNull.Value && (bool)pIsUpdated.Value;
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return false;
        }

        public static async Task<DataTable> GetAllFraudFlagsAsync()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAllFraudFlags()", conn))
            {
                try
                {
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        dt.Load(reader);

                    return dt;
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return null;
        }

        public static async Task<DataTable> GetUnresolvedFraudFlagsAsync()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetUnresolvedFraudFlags()", conn))
            {
                try
                {
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        dt.Load(reader);

                    return dt;
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return null;
        }

        public static async Task<DataTable> GetFraudFlagsByAccountIDAsync(int accountID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAllFraudFlags() WHERE AccountID = @AccountID", conn))
            {
                cmd.Parameters.AddWithValue("@AccountID", accountID);

                try
                {
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        dt.Load(reader);

                    return dt;
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return null;
        }
    }
}
