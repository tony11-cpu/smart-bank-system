using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    public class clsUtil
    {
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
