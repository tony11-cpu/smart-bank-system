using SmartBank;
using SmartBank_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using static SmartBank_BLL.clsUtil.clsSecurity.clsHash;

namespace SmartBank
{
    public class clsUsers
    {
        public enum enMode { Add , Update }
        private enMode _mode;

        public int? UserID { get; private set; }
        public string Username { get; set; }
        public clsPermissions Permissions { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; private set; }
        public bool IsLocked { get; set; }
        public DateTime? CreatedDate { get; private set; }
        public DateTime? LastLoginDate { get; private set; } = null;
        public string PasswordSalt { get; private set; }
        public string HashedPassword { get; private set; }
        public string Password { get; set; }
        public string CreatedByUserUsername { get; private set; }
        public string ImagePath { get; set; }

        public clsUsers(int userID, string username, clsPermissions permissions, 
                        string fullName, bool isActive, bool isLocked, 
                        DateTime? createdDate, DateTime? lastLoginDate, 
                        string passwordSalt, string hashedPassword , string createdByUserUsername , string imagePath)
        {
            UserID = userID;
            Username = username;
            Permissions = permissions;
            FullName = fullName;
            IsActive = isActive;
            IsLocked = isLocked;
            CreatedDate = createdDate;
            LastLoginDate = lastLoginDate;
            PasswordSalt = passwordSalt;
            HashedPassword = hashedPassword;
            this.CreatedByUserUsername = createdByUserUsername;
            ImagePath = imagePath;

            _mode = enMode.Update;
        }

        public clsUsers()
        {
            UserID = null;
            Username = null;
            Permissions = null;     
            FullName = null;
            IsActive = false;
            IsLocked = true;
            CreatedDate = null;
            LastLoginDate = null;
            PasswordSalt = null;
            HashedPassword = null;
            CreatedByUserUsername = null;
            ImagePath = null;
        }

        public static async Task<bool> IsUserExistsAsync(int userID) => await clsUsers_DAL.IsUserExistByIDAsync(userID);

        public static async Task<bool> IsUserExistsAsync(string Username) => await clsUsers_DAL.IsUserExistByUsernameAsync(Username);

        /// <summary>
        /// Use try and catch block to handle the exception of user ID not being set, which can occur if you try to record a login attempt for a user that hasn't been saved to the database yet.
        /// </summary>
        /// <exception cref="Exception">User ID not being set</exception>
        public async Task RecordLoginAttemptAsync(bool wasSuccessful) => await clsUsers_DAL.RecordLoginAttemptAsync(UserID ?? throw new Exception("User ID is not set."), wasSuccessful);

        /// <summary>
        /// Use try and catch block to handle the exception of user ID not being set, which can occur if you try to record a login attempt for a user that hasn't been saved to the database yet.
        /// </summary>
        /// <param name="username"></param>
        /// <exception cref="Exception">User ID not being set</exception>
        public static async Task<clsUsers> FindAsync(string username)
        {
            var getUser = await clsUsers_DAL.GetUserByUsernameAsync(username);

            if (getUser != null) 
            {
                return new clsUsers(getUser.UserID ?? throw new Exception("User ID is not set."), username, new clsPermissions(getUser.Permissions), 
                                    getUser.FullName, getUser.IsActive, getUser.IsLocked, getUser.CreationDate , 
                                    getUser.LastLoginDate, getUser.PasswordSalt , getUser.PasswordHash , getUser.CreatedByUsername , getUser.ImagePath);
            }

            return null;
        }

        /// <summary>
        /// Use try and catch block to handle the exception of user ID not being set, which can occur if you try to record a login attempt for a user that hasn't been saved to the database yet.
        /// </summary>
        /// <exception cref="Exception">User ID not being set</exception>
        public static async Task<clsUsers> FindAsync(int userID)
        {
            var getUser = await clsUsers_DAL.GetUserByUserIDAsync(userID);

            if (getUser != null)
            {
                return new clsUsers(getUser.UserID ?? throw new Exception("User ID is not set."), getUser.Username, new clsPermissions(getUser.Permissions),
                                    getUser.FullName, getUser.IsActive, getUser.IsLocked, getUser.CreationDate,
                                    getUser.LastLoginDate, getUser.PasswordSalt, getUser.PasswordHash, getUser.CreatedByUsername, getUser.ImagePath);
            }

            return null;
        }

        private async Task<bool> _addNewAsync()
        {
            string passwardSalt = GenerateSalt();
            var UserID = await clsUsers_DAL.CreateUserAsync(clsGlobal.ActiveUser.UserID ?? throw new Exception("No user responsible"),
                                                        new clsUserDto(null , Username , Hash(Password, passwardSalt), passwardSalt , Permissions.Permissions, FullName,
                                                        true, false, DateTime.Now, null , null, ImagePath));

            if (UserID == -1)
                return false;

            _mode = enMode.Update;
            return true;
        }

        private async Task<bool> _updateAsync()
        {
            bool isPasswordChanged = !Password.Equals(HashedPassword);
            string passwardSalt = isPasswordChanged ? GenerateSalt() : PasswordSalt;

            return await clsUsers_DAL.UpdateUserAsync(clsGlobal.ActiveUser == null ? throw new Exception("No Admin Responsible!") : clsGlobal.ActiveUser.UserID, 
                                                      new clsUserDto(UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!"), Username, 
                                                                     isPasswordChanged ? Hash(Password, passwardSalt) : HashedPassword,
                                                                     passwardSalt, Permissions.Permissions, FullName, IsActive, IsLocked, LastLoginDate, 
                                                                     LastLoginDate , CreatedByUserUsername , ImagePath));
        }

        public static async Task<List<clsUsers>> GetAllUsersAsync()
        {
            List<clsUsers> users = new List<clsUsers>();
            DataTable dt = await clsUsers_DAL.GetAllUsersAsync();

            foreach (DataRow row in dt.Rows)
            {
                users.Add(new clsUsers(
                    (int)row["UserID"],
                    row["Username"].ToString(),
                    new clsPermissions((int)row["Permissions"]),
                    row["FullName"].ToString(),
                    (bool)row["IsActive"],
                    (bool)row["IsLocked"],
                    (DateTime)row["CreatedDate"],
                    row["LastLoginDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["LastLoginDate"],
                    row["PasswordSalt"].ToString(),
                    row["PasswordHash"].ToString(),
                    row["CreatedByUserUsername"].ToString(),
                    row["ImagePath"].ToString()
                ));
            }

            return users;
        }

        /// <summary>
        /// Make sure to use this method in a try and catch block to handle the exception of user ID not being set, which can occur if you try to get login records for a user that hasn't been saved to the database yet.
        /// </summary>
        /// <returns></returns>
        public async Task<DataTable> GetUserLoginRecorsAsync() => await clsUsers_DAL.GetAllUserLoginAttemptsAsync(this.UserID ?? throw new Exception("User ID is not set."));

        public static async Task<DataTable> GetAllLoginAttemptsAsync() => await clsUsers_DAL.GetAllLoginAttemptsAsync();

        public async Task<bool> SaveAsync()
        {
            switch(_mode)
            {
                case enMode.Add: return await _addNewAsync();
                case enMode.Update: return await _updateAsync();

                default:
                    throw new InvalidOperationException("Invalid mode for saving user.");
            }
        }

        public async Task<bool> DeactivateAsync()
        {
            if(_mode == enMode.Update && await clsUsers_DAL.DeactivateUserAsync(clsGlobal.ActiveUser.UserID ?? throw new Exception("No Admin Responsible!"),
                                                                               UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!")))
            {
                IsActive = false;
                return true;
            }

            return false;
        }

        public async Task<bool> ActivateAsync()
        {
            if(_mode == enMode.Update && await clsUsers_DAL.ActivateUserAsync(clsGlobal.ActiveUser.UserID ?? throw new Exception("No Admin Responsible!"),
                                                                              UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!")))
            {
                IsActive = true;
                return true;
            }

            return false;
        }

        public async Task<bool> LockAsync()
        {
            if(_mode == enMode.Update && await clsUsers_DAL.LockUserAsync(clsGlobal.ActiveUser == null ? null : clsGlobal.ActiveUser.UserID,
                                                               UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!")))
            {
                IsLocked = true;
                return true;
            }

            return false;
        }

        public async Task<bool> UnlockAsync()
        {
            if(_mode == enMode.Update && await clsUsers_DAL.UnlockUserAsync(clsGlobal.ActiveUser.UserID ?? throw new Exception("No Admin Responsible!"), 
                                                                            UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!")))
            {
                IsLocked = false;
                return true;
            }

            return false;
        }
    }
}
