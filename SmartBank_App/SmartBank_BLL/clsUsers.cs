using SmartBank;
using SmartBank_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

        public static bool IsUserExists(int userID) => clsUsers_DAL.IsUserExistByID(userID);

        public static bool IsUserExists(string Username) => clsUsers_DAL.IsUserExistByUsername(Username);

        public void RecordLoginAttemp(bool wasSuccessful) => clsUsers_DAL.RecordLoginAttempt(UserID ?? throw new Exception("User ID is not set."), wasSuccessful);

        public static clsUsers Find(string username)
        {
            int userID = -1;
            string passwordHash = null;
            string passwordSalt = null;
            int permissions = 0;
            string fullName = null;
            bool isActive = false;
            bool isLocked = false;
            DateTime? creationDate = null;
            DateTime? lastLogInDate = null;
            string usernameCreatedCurrentUser = null;
            string imagePath = null;

            if (clsUsers_DAL.GetUserByUsername(username, ref userID, ref passwordHash, ref passwordSalt, ref permissions, ref fullName,
                                                         ref isActive, ref isLocked, ref creationDate, ref lastLogInDate , ref usernameCreatedCurrentUser , ref imagePath)) 
            {
                return new clsUsers(userID, username, new clsPermissions(permissions), 
                                    fullName, isActive, isLocked, creationDate , 
                                    lastLogInDate, passwordSalt , passwordHash , usernameCreatedCurrentUser , imagePath);
            }

            return null;
        }

        public static clsUsers Find(int userID)
        {
            string username = null;
            string passwordHash = null;
            string passwordSalt = null;
            int permissions = 0;
            string fullName = null;
            bool isActive = false;
            bool isLocked = false;
            DateTime? creationDate = null;
            DateTime? lastLogInDate = null;
            string usernameCreatedCurrentUser = null;
            string imagePath = null;

            if (clsUsers_DAL.GetUserByUserID(userID, ref username, ref passwordHash, ref passwordSalt, ref permissions, ref fullName,
                                                         ref isActive, ref isLocked, ref creationDate, ref lastLogInDate, ref usernameCreatedCurrentUser, ref imagePath))
            {
                return new clsUsers(userID, username, new clsPermissions(permissions),
                                    fullName, isActive, isLocked, creationDate,
                                    lastLogInDate, passwordSalt, passwordHash, usernameCreatedCurrentUser, imagePath);
            }

            return null;
        }

        private bool _addNew()
        {
            string passwardSalt = GenerateSalt();
            UserID = clsUsers_DAL.CreateUser(clsGlobal.ActiveUser.UserID, Username, Hash(Password , passwardSalt) , passwardSalt ,
                                             Permissions.Permissions, FullName, true, false , DateTime.Now , ImagePath);
            if (UserID == -1)
                return false;

            _mode = enMode.Update;
            return true;
        }

        private bool _update()
        {
            bool isPasswordChanged = !Password.Equals(HashedPassword);
            string passwardSalt = isPasswordChanged ? GenerateSalt() : PasswordSalt;

            return clsUsers_DAL.UpdateUser(clsGlobal.ActiveUser == null ? throw new Exception("No Admin Responsible!") : clsGlobal.ActiveUser.UserID,
                                           UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!"), Username, isPasswordChanged ? Hash(Password, passwardSalt) : HashedPassword,
                                           passwardSalt, Permissions.Permissions, FullName, IsActive, IsLocked, LastLoginDate, ImagePath);
        }

        public static List<clsUsers> GetAllUsers()
        {
            DataTable dt = clsUsers_DAL.GetAllUsers();
            List<clsUsers> users = new List<clsUsers>();

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
        /// <exception cref="Exception"></exception>
        public DataTable GetUserLoginRecors() => clsUsers_DAL.GetAllUserLoginAttempts(this.UserID ?? throw new Exception("User ID is not set."));

        public bool Save()
        {
            switch(_mode)
            {
                case enMode.Add: return _addNew();
                case enMode.Update: return _update();

                default:
                    throw new InvalidOperationException("Invalid mode for saving user.");
            }
        }

        public bool Deactivate()
        {
            if(_mode == enMode.Update && clsUsers_DAL.DeactivateUser(clsGlobal.ActiveUser.UserID ?? throw new Exception("No Admin Responsible!"),
                UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!")))
            {
                IsActive = false;
                return true;
            }

            return false;
        }

        public bool Activate()
        {
            if(_mode == enMode.Update && clsUsers_DAL.ActivateUser(clsGlobal.ActiveUser.UserID ?? throw new Exception("No Admin Responsible!"),
                UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!")))
            {
                IsActive = true;
                return true;
            }

            return false;
        }

        public bool Lock()
        {
            if(_mode == enMode.Update && clsUsers_DAL.LockUser(clsGlobal.ActiveUser.UserID ?? throw new Exception("No Admin Responsible!"),
                UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!")))
            {
                IsLocked = true;
                return true;
            }

            return false;
        }

        public bool Unlock()
        {
            if(_mode == enMode.Update && clsUsers_DAL.UnlockUser(clsGlobal.ActiveUser.UserID ?? throw new Exception("No Admin Responsible!"), 
                UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!")))
            {
                IsLocked = false;
                return true;
            }

            return false;
        }
    }
}