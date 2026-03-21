using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using SmartBank;

namespace SmartBank
{
    public class clsUsers
    {
        public enum enMode { Add , Update }
        private enMode _mode;

        public int? UserID { get; private set; }
        public string Username { get; set; }
        public clsPermissions Permissions { get; private set; }
        public string FullName { get; set; }
        public bool IsActive { get; private set; }
        public bool IsLocked { get; private set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; } = null;
        public string PasswordSalt { get; set; }
        public string HashedPassword { get; set; }

        public clsUsers(int userID, string username, clsPermissions permissions, 
                        string fullName, bool isActive, bool isLocked, 
                        DateTime createdDate, DateTime? lastLoginDate, 
                        string passwordSalt, string hashedPassword)
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

            _mode = enMode.Update;
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
            DateTime creationDate = DateTime.MinValue;
            DateTime? lastLogInDate = null;

            if (clsUsers_DAL.GetUserByUsername(username, ref userID, ref passwordHash, ref passwordSalt, ref permissions, ref fullName,
                                                         ref isActive, ref isLocked, ref creationDate, ref lastLogInDate)) 
            {
                return new clsUsers(userID, username, new clsPermissions(permissions), 
                                    fullName, isActive, isLocked, creationDate, 
                                    lastLogInDate, passwordSalt , passwordHash);
            }

            return null;
        }

        private bool _addNew()
        {
            UserID = clsUsers_DAL.CreateUser(clsGlobal.ActiveUser.UserID, Username, HashedPassword, PasswordSalt,
                                             Permissions.Permissions, FullName, IsActive, IsLocked);

            _mode = enMode.Update;
            return UserID != -1;
        }

        private bool _update() => clsUsers_DAL.UpdateUser(clsGlobal.ActiveUser == null ? null : clsGlobal.ActiveUser.UserID, 
                                                          UserID ?? throw new Exception("User ID Is Not Yet Setted For Update!"), Username, HashedPassword, PasswordSalt,
                                                          Permissions.Permissions, FullName, IsActive, IsLocked , LastLoginDate);

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
            if (UserID != clsGlobal.ActiveUser.UserID && _mode == enMode.Update)
            {
                IsActive = false;
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