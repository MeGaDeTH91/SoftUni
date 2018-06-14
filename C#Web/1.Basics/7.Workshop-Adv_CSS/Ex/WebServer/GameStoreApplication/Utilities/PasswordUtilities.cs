using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HTTPServer.GameStoreApplication.Utilities
{
    public static class PasswordUtilities
    {
        public static string GenerateHash(string inputString)
        {
            string hashString;

            using(var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.Default.GetBytes(inputString));

                hashString = ToHex(hash, false);
            }

            return hashString;
        }

        private static string ToHex(byte[] bytes, bool uppercase)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString(uppercase ? "X2" : "x2"));
            }

            return sb.ToString();
        }
    }
}
