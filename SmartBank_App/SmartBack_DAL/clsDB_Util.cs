using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartBack_DAL
{
    public class clsDB_Util
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["SmartBankDB"].ConnectionString;

        public partial class clsLogger
        {
            /// <summary>
            /// Log Message With Message Type To Event Viewer
            /// </summary>
            /// <param name="type">Event Viewer Type Enum</param>
            public static void Log(string message, EventLogEntryType type = EventLogEntryType.Error)
            {
                string source = "SmartBank_Project";

                if (!EventLog.SourceExists(source))
                    EventLog.CreateEventSource(source, "Application");

                EventLog.WriteEntry(source, message, type);
            }

            /// <summary>
            /// Save User Data To Registry To Load It On Next Login And Avoid Database Call For User Data
            /// </summary>
            public static bool LogToRegistry(string username, string passwordHash)
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SmartBank_User"))
                    {
                        if (key == null) throw new Exception("Failed to create registry key.");

                        key.SetValue("Username", username, RegistryValueKind.String);
                        key.SetValue("PasswordHash", passwordHash, RegistryValueKind.String);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Log($"Failed to save user to registry: {ex.Message}", EventLogEntryType.Error);
                    return false;
                }
            }

            public static (string Username , string Password) ReadUserDataFromRegistry()
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SmartBank_User"))
                    {
                        if (key == null) throw new Exception("Registry key not found.");

                        string username = key.GetValue("Username" , string.Empty).ToString();
                        string password = key.GetValue("PasswordHash", string.Empty).ToString();

                        return string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ? (null , null) : (username, password);
                    }
                }
                catch (Exception ex)
                {
                    Log($"Failed to read user from registry: {ex.Message}", EventLogEntryType.Error);
                    return (null, null);
                }
            }
        }

        public static bool IsDatabaseConnected()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
