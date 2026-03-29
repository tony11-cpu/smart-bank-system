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

        public void RecordLoginAttemp(bool wasSuccessful) => clsUsers_DAL.RecordLoginAttempt(Username, wasSuccessful);

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

        private bool _addNew()
        {
            string passwardSalt = GenerateSalt();
            UserID = clsUsers_DAL.CreateUser(clsGlobal.ActiveUser.UserID, Username, Hash(Password , passwardSalt) , passwardSalt ,
                                             Permissions.Permissions, FullName, true, false , DateTime.Now , ImagePath);
            _mode = enMode.Update;
            return UserID != -1;
        }

        private bool _update()
        {
            string passwardSalt = GenerateSalt();
            return clsUsers_DAL.UpdateUser(clsGlobal.ActiveUser == null ? null : clsGlobal.ActiveUser.UserID,
                                                          UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!"), Username, Hash(Password, passwardSalt), passwardSalt,
                                                          Permissions.Permissions, FullName, IsActive, IsLocked, LastLoginDate, ImagePath);
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

        public DataTable GetUserLoginRecors() => clsUsers_DAL.GetAllUserLoginAttempts(this.Username);

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
            if (_mode == enMode.Update)
            {
                IsActive = false;
                return _update();
            }

            return false;
        }

        public bool Activate()
        {
            if (_mode == enMode.Update)
            {
                IsActive = true;
                return _update();
            }

            return false;
        }

        public bool Lock()
        {
            if (_mode != enMode.Update) return false;

            IsLocked = true;
            return _update();
        }

        public bool Unlock()
        {
            if (_mode != enMode.Update) return false;

            IsLocked = false;
            return _update();
        }
    }
}