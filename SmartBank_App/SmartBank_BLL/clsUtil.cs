using Microsoft.Win32;
using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.IO;
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
            public static class clsHash
            {
                private const int SaltSize = 32;

                /// <summary>
                /// Generates a cryptographically secure random salt.
                /// </summary>
                public static string GenerateSalt()
                {
                    byte[] saltBytes = new byte[SaltSize];
                    using (var rng = new RNGCryptoServiceProvider())
                        rng.GetBytes(saltBytes);
                    return Convert.ToBase64String(saltBytes);
                }

                /// <summary>
                /// Hashes a password combined with a salt using SHA-256.
                /// </summary>
                public static string Hash(string password, string salt)
                {
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] combinedBytes = Encoding.UTF8.GetBytes(password + salt);
                        byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                        return Convert.ToBase64String(hashBytes);
                    }
                }
            }

            public static bool Verify(string password, string storedHash, string storedSalt) => clsHash.Hash(password, storedSalt) == storedHash;

            public static class clsCryptography
            {
                /// <summary>Encrypts a plaintext message using AES-256.</summary>
                public static string Encrypt(string plainText)
                {
                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(clsConfigurations.EncryptionKey));
                        aes.GenerateIV();

                        using (var ms = new MemoryStream())
                        {
                            ms.Write(aes.IV, 0, aes.IV.Length);

                            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                                cs.Write(plainBytes, 0, plainBytes.Length);
                                cs.FlushFinalBlock();
                            }

                            return Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }

                /// <summary>Decrypts an AES-256 encrypted Base64 string.</summary>
                public static string Decrypt(string cipherText)
                {
                    byte[] fullData = Convert.FromBase64String(cipherText);

                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(clsConfigurations.EncryptionKey));
                        aes.IV = fullData.Take(16).ToArray();

                        using (var ms = new MemoryStream(fullData, 16, fullData.Length - 16))
                        using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        using (var sr = new StreamReader(cs))
                            return sr.ReadToEnd();
                    }
                }
            }
        }

        public static class clsLogger
        {
            static public bool SaveUserDataToRegistry(string username, string password) => 
                                clsDB_Util.clsLogger.LogToRegistry(username, clsSecurity.clsCryptography.Encrypt(password));
            static public (string Username , string Password) ReadUserDataFromRegistry()
            {
                (string ,string Password) result = clsDB_Util.clsLogger.ReadUserDataFromRegistry();

                if (result != (null, null))
                    result.Password = clsSecurity.clsCryptography.Decrypt(result.Password);

                return result;
            }
        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };
            string ext = new FileInfo(sourceFile).Extension.ToLower();

            if (!allowedExtensions.Contains(ext))
                return false;

            string destinationFolder = @"C:\SmartBankCustomers_Images\";

            if (!Directory.Exists(destinationFolder))
                Directory.CreateDirectory(destinationFolder);

            string destinationFile = Path.Combine(destinationFolder, Guid.NewGuid().ToString() + ext);

            try
            {
                File.Copy(sourceFile, destinationFile, true);
                sourceFile = destinationFile;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDatabaseConnected() => clsDB_Util.IsDatabaseConnected();
    }
}