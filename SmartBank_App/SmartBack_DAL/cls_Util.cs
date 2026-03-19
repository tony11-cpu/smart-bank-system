using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartBack_DAL
{
    internal static class cls_Util
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["SmartBankDB"].ConnectionString;

        public static class clsLogger
        {
            public static void Log(string message, EventLogEntryType type = EventLogEntryType.Error)
            {
                string source = "SmartBank_Project";

                if (!EventLog.SourceExists(source))
                    EventLog.CreateEventSource(source, "Application");

                EventLog.WriteEntry(source, message, type);
            }
        }

        public static class clsSecurity
        {
            private const int SaltSize = 32;

            public static string GenerateSalt()
            {
                byte[] saltBytes = new byte[SaltSize];
                using (var rng = new RNGCryptoServiceProvider()) rng.GetBytes(saltBytes);
                return Convert.ToBase64String(saltBytes);
            }

            public static string Hash(string password, string salt)
            {
                using (var sha256 = SHA256.Create())
                {
                    byte[] combined = Encoding.UTF8.GetBytes(password + salt);
                    byte[] hashBytes = sha256.ComputeHash(combined);
                    return Convert.ToBase64String(hashBytes);
                }
            }

            public static bool Verify(string password, string hash, string salt) => Hash(password, salt) == hash;
        }
    }
}
