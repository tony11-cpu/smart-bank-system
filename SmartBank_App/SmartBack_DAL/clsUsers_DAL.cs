using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SmartBank
{
    public static class clsUsers_DAL
    {
        public static bool IsUserExistByUsername(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsUserExistByUsername(@Username)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();

                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static bool IsUserExistByID(int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsUserExistByID(@UserID)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    conn.Open();

                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static bool GetUserByUsername(string username, ref int userID, ref string passwordHash,
                                         ref string passwordSalt, ref int permissions,
                                         ref string fullName, ref bool isActive, ref bool isLocked,
                                         ref DateTime? creationDate, ref DateTime? lastLogInDate ,ref string createdByUserUsername , ref string imagePath)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetUserByUsername", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);

                    SqlParameter pUserID = new SqlParameter("@UserID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter pPasswordHash = new SqlParameter("@PasswordHash", SqlDbType.NVarChar, 300) { Direction = ParameterDirection.Output };
                    SqlParameter pPasswordSalt = new SqlParameter("@PasswordSalt", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };
                    SqlParameter pPermissions = new SqlParameter("@Permissions", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter pFullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };
                    SqlParameter pCreationDate = new SqlParameter("@CreationDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
                    SqlParameter pLastLogInDate = new SqlParameter("@LastLoginDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
                    SqlParameter pIsActive = new SqlParameter("@IsActive", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    SqlParameter pIsLocked = new SqlParameter("@IsLocked", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    SqlParameter pCreatedByUsername = new SqlParameter("@CreatedByUsername", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };
                    SqlParameter pImagePath = new SqlParameter("@imagePath", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(pUserID);
                    cmd.Parameters.Add(pPasswordHash);
                    cmd.Parameters.Add(pPasswordSalt);
                    cmd.Parameters.Add(pPermissions);
                    cmd.Parameters.Add(pFullName);
                    cmd.Parameters.Add(pCreationDate);
                    cmd.Parameters.Add(pLastLogInDate);
                    cmd.Parameters.Add(pIsActive);
                    cmd.Parameters.Add(pIsLocked);
                    cmd.Parameters.Add(pCreatedByUsername);
                    cmd.Parameters.Add(pImagePath);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    if (pUserID.Value == DBNull.Value) return false;

                    userID = (int)pUserID.Value;
                    passwordHash = (string)pPasswordHash.Value;
                    passwordSalt = (string)pPasswordSalt.Value;
                    permissions = (int)pPermissions.Value;
                    fullName = (string)pFullName.Value;
                    isActive = (bool)pIsActive.Value;
                    isLocked = (bool)pIsLocked.Value;
                    creationDate = (DateTime)pCreationDate.Value;
                    lastLogInDate = pLastLogInDate.Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(pLastLogInDate.Value);
                    createdByUserUsername = pCreatedByUsername.Value == DBNull.Value ? null : (string)pCreatedByUsername.Value;
                    imagePath = pImagePath.Value == DBNull.Value ? null : (string)pImagePath.Value;

                    return true;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static int CreateUser(int? userInActionID, string username, string hashedPassword,
                                      string salt, int permissions, string fullName,
                                      bool isActive, bool isLocked , DateTime creationDate , string imagePath)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_CreateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserInActionID", userInActionID);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                    cmd.Parameters.AddWithValue("@Salt", salt);
                    cmd.Parameters.AddWithValue("@Permissions", permissions);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);
                    cmd.Parameters.AddWithValue("@IsLocked", isLocked);
                    cmd.Parameters.AddWithValue("@CreationDate", creationDate == null ? (object)DBNull.Value : creationDate);
                    cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);

                    SqlParameter newUserID = new SqlParameter("@NewUserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(newUserID);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (int)newUserID.Value;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return -1;
        }

        public static void RecordLoginAttempt(int userID, bool wasSuccessful)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_RecordLoginAttempt", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@WasSuccessful", wasSuccessful);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }
        }

        public static bool UpdateUser(int? adminUserID, int userID, string username,
                                      string passwordHash, string passwordSalt, int permissions,
                                      string fullName, bool isActive, bool isLocked,
                                      DateTime? lastLoginDate , string imagePath)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdminUserID", adminUserID == null ? (object)DBNull.Value : adminUserID);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    cmd.Parameters.AddWithValue("@PasswordSalt", passwordSalt);
                    cmd.Parameters.AddWithValue("@Permissions", permissions);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);
                    cmd.Parameters.AddWithValue("@IsLocked", isLocked);
                    cmd.Parameters.AddWithValue("@LastLoginDate", lastLoginDate.HasValue ? (object)lastLoginDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);

                    SqlParameter pIsUpdated = new SqlParameter("@IsUpdated", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(pIsUpdated);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return Convert.ToBoolean(pIsUpdated.Value);
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("select * From fn_GetAllUsers();", conn))
                {
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return dt;
        }

        public static DataTable GetAllUserLoginAttempts(int userID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAllUserLoginAttempt(@UserID)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
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