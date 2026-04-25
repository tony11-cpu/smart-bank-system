using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartBank
{
    public class clsUserDto
    {
        public int? UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int Permissions { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string CreatedByUsername { get; set; }
        public string ImagePath { get; set; }

        public clsUserDto(int? userID, string username, string passwordHash, string passwordSalt, int permissions, 
                       string fullName, bool isActive, bool isLocked, DateTime? creationDate, DateTime? lastLoginDate,
                       string createdByUsername, string imagePath)
        {
            UserID = userID;
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Permissions = permissions;
            FullName = fullName;
            IsActive = isActive;
            IsLocked = isLocked;
            CreationDate = creationDate;
            LastLoginDate = lastLoginDate;
            CreatedByUsername = createdByUsername;
            ImagePath = imagePath;
        }
    }

    public static class clsUsers_DAL
    {
        public static async Task<bool> IsUserExistByUsernameAsync(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsUserExistByUsername(@Username)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Username", username);
                    await conn.OpenAsync();

                    return Convert.ToBoolean(await cmd.ExecuteScalarAsync());
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static async Task<bool> IsUserExistByIDAsync(int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsUserExistByID(@UserID)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    await conn.OpenAsync();

                    return Convert.ToBoolean(await cmd.ExecuteScalarAsync());
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static async Task<clsUserDto> GetUserByUsernameAsync(string username)
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

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    if (pUserID.Value == DBNull.Value)
                        return null;

                    return new clsUserDto((int)pUserID.Value, username, (string)pPasswordHash.Value,
                        (string)pPasswordSalt.Value, (int)pPermissions.Value, (string)pFullName.Value,
                        (bool)pIsActive.Value, (bool)pIsLocked.Value, pCreationDate.Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(pCreationDate.Value),
                        pLastLogInDate.Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(pLastLogInDate.Value),
                        pCreatedByUsername.Value == DBNull.Value ? null : (string)pCreatedByUsername.Value,
                        pImagePath.Value == DBNull.Value ? null : (string)pImagePath.Value
                    );
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return null;
        }

        public static async Task<int> CreateUserAsync(int? userInActionID, clsUserDto userToCreate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_CreateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserInActionID", userInActionID);
                    cmd.Parameters.AddWithValue("@Username", userToCreate.Username);
                    cmd.Parameters.AddWithValue("@HashedPassword", userToCreate.PasswordHash);
                    cmd.Parameters.AddWithValue("@Salt", userToCreate.PasswordSalt);
                    cmd.Parameters.AddWithValue("@Permissions", userToCreate.Permissions);
                    cmd.Parameters.AddWithValue("@FullName", userToCreate.FullName);
                    cmd.Parameters.AddWithValue("@IsActive", userToCreate.IsActive);
                    cmd.Parameters.AddWithValue("@IsLocked", userToCreate.IsLocked);
                    cmd.Parameters.AddWithValue("@CreationDate", userToCreate.CreationDate == null ? (object)DBNull.Value : userToCreate.CreationDate);
                    cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(userToCreate.ImagePath) ? (object)DBNull.Value : userToCreate.ImagePath);

                    SqlParameter newUserID = new SqlParameter("@NewUserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(newUserID);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return (int)newUserID.Value;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return -1;
        }

        public static async Task RecordLoginAttemptAsync(int userID, bool wasSuccessful)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_RecordLoginAttempt", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@WasSuccessful", wasSuccessful);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }
        }

        public static async Task<bool> UpdateUserAsync(int? adminUserID, clsUserDto userToUpdate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdminUserID", adminUserID == null ? (object)DBNull.Value : adminUserID);
                    cmd.Parameters.AddWithValue("@UserID", userToUpdate.UserID);
                    cmd.Parameters.AddWithValue("@Username", userToUpdate.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", userToUpdate.PasswordHash);
                    cmd.Parameters.AddWithValue("@PasswordSalt", userToUpdate.PasswordSalt);
                    cmd.Parameters.AddWithValue("@Permissions", userToUpdate.Permissions);
                    cmd.Parameters.AddWithValue("@FullName", userToUpdate.FullName);
                    cmd.Parameters.AddWithValue("@IsActive", userToUpdate.IsActive);
                    cmd.Parameters.AddWithValue("@IsLocked", userToUpdate.IsLocked);
                    cmd.Parameters.AddWithValue("@LastLoginDate", userToUpdate.LastLoginDate.HasValue ? (object)userToUpdate.LastLoginDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(userToUpdate.ImagePath) ? (object)DBNull.Value : userToUpdate.ImagePath);
                    SqlParameter pIsUpdated = new SqlParameter("@IsUpdated", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(pIsUpdated);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return Convert.ToBoolean(pIsUpdated.Value);
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static async Task<DataTable> GetAllUsersAsync()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("select * From fn_GetAllUsers();", conn))
                {
                    await conn.OpenAsync();
                    using(SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        dt.Load(reader);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return null;
        }

        public static async Task<DataTable> GetAllUserLoginAttemptsAsync(int userID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAllUserLoginAttempt(@UserID)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", userID);
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

        public static async Task<clsUserDto> GetUserByUserIDAsync(int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetUserByUserID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);

                    SqlParameter pUsername = new SqlParameter("@Username", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                    SqlParameter pPasswordHash = new SqlParameter("@PasswordHash", SqlDbType.NVarChar, 300) { Direction = ParameterDirection.Output };
                    SqlParameter pPasswordSalt = new SqlParameter("@PasswordSalt", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };
                    SqlParameter pPermissions = new SqlParameter("@Permissions", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter pFullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };
                    SqlParameter pCreationDate = new SqlParameter("@CreationDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
                    SqlParameter pLastLogInDate = new SqlParameter("@LastLoginDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
                    SqlParameter pIsActive = new SqlParameter("@IsActive", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    SqlParameter pIsLocked = new SqlParameter("@IsLocked", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    SqlParameter pCreatedByUsername = new SqlParameter("@CreatedByUsername", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };
                    SqlParameter pImagePath = new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(pUsername);
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

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    if (pUsername.Value == DBNull.Value) 
                        return null;

                    return new clsUserDto(userID, (string)pUsername.Value, (string)pPasswordHash.Value,
                        (string)pPasswordSalt.Value, (int)pPermissions.Value, (string)pFullName.Value,
                        (bool)pIsActive.Value, (bool)pIsLocked.Value, pCreationDate.Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(pCreationDate.Value),
                        pLastLogInDate.Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(pLastLogInDate.Value),
                        pCreatedByUsername.Value == DBNull.Value ? null : (string)pCreatedByUsername.Value,
                        pImagePath.Value == DBNull.Value ? null : (string)pImagePath.Value
                    );
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return null;
        }

        public static async Task<bool> DeactivateUserAsync(int adminUserID, int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeactivateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdminUserID", adminUserID);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    SqlParameter pIsUpdated = new SqlParameter("@IsUpdated", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(pIsUpdated);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return pIsUpdated.Value != DBNull.Value && (bool)pIsUpdated.Value;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static async Task<bool> ActivateUserAsync(int adminUserID, int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_ActivateUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdminUserID", adminUserID);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    SqlParameter pIsUpdated = new SqlParameter("@IsUpdated", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(pIsUpdated);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return pIsUpdated.Value != DBNull.Value && (bool)pIsUpdated.Value;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static async Task<bool> LockUserAsync(int? adminUserID, int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_LockUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdminUserID", adminUserID.HasValue ? (object)adminUserID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    SqlParameter pIsUpdated = new SqlParameter("@IsUpdated", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(pIsUpdated);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return pIsUpdated.Value != DBNull.Value && (bool)pIsUpdated.Value;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static async Task<bool> UnlockUserAsync(int adminUserID, int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UnlockUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdminUserID", adminUserID);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    SqlParameter pIsUpdated = new SqlParameter("@IsUpdated", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(pIsUpdated);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return pIsUpdated.Value != DBNull.Value && (bool)pIsUpdated.Value;
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