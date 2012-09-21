using System;
using System.Security.Cryptography;
using System.Text;

namespace ServiceLib
{
    public static class SecurityOperations
    {
        public static string CreateSalt()
        {
            int lenSalt = 8;
            byte[] saltArray = new byte[lenSalt];
            RandomNumberGenerator generator = new RNGCryptoServiceProvider();
            generator.GetBytes(saltArray);
            return ByteArrayToString(saltArray);
        }

        public static string GetHash(string text)
        {
            string hash = null;
            using (SHA1 shaHash = SHA1.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = shaHash.ComputeHash(Encoding.ASCII.GetBytes(text));
                hash = ByteArrayToString(data);
            }
            return hash;
        }

        public static string FillPassHash(string password, out string salt)
        {
            salt = CreateSalt();
            return PassHashMixGet(password, salt);
        }

        public static string ChangePassHash(string newPassword, string passSalt)
        {
            return PassHashMixGet(newPassword, passSalt);
        }

        public static bool CheckPass (string password, string passwordHash, string salt)
        {
            var resHash = PassHashMixGet(password, salt);
            return resHash == passwordHash;
        }

        private static string ByteArrayToString(byte[] data)
        {
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int n = 0; n < data.Length; n++)
            {
                sBuilder.Append(data[n].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private static string PassHashMixGet(string pass, string salt)
        {
            string result;
            result = GetHash(salt + pass);
            return result;
        }

        
    }
}