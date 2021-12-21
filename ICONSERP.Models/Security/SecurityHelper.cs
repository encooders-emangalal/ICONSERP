using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static ICONSERP.Models.Enums.Enums;

namespace ICONSERP.Models.Security
{
    public static class SecurityHelper
    {
        private const string _alg = "HmacSHA256";
        private const string _salt = "YrBuEnADCObpoxOodqjc";
        public static string GenerateToken(long userID, UserType UserType)

        {
            int usert = (int)UserType;
            var user = $"{userID}:{usert}";
            string hash = string.Join(":", new string[] { user, Guid.NewGuid().ToString(), DateTime.Now.Ticks.ToString() });
            string hashLeft = "";
            string hashRight = "";
            using (HMAC hmac = HMAC.Create(_alg))
            {
                hmac.Key = Encoding.UTF8.GetBytes(_salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));
                hashLeft = Convert.ToBase64String(hmac.Hash);
                hashRight = string.Join(":", new string[] { user, DateTime.Now.AddDays(10).Ticks.ToString() });
            }
            string accessToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashLeft, hashRight)));
            return accessToken;
        }
        public static string GetHashedString(string word)
        {
            string key = string.Join(":", new string[] { word, _salt });
            using (HMAC hmac = HMAC.Create(_alg))
            {
                hmac.Key = Encoding.UTF8.GetBytes(_salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));
                return Convert.ToBase64String(hmac.Hash);
            }
        }
        public static bool IsTokenExpired(string token)
        {
            bool validToken = false;
            try
            {
                string key = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                string[] parts = key.Split(new char[] { ':' });
                if (parts.Length == 3)
                {
                    string hash = parts[0];
                    long userID = int.Parse(parts[1]);
                    long ticks = long.Parse(parts[3]);
                    DateTime expirationTime = new DateTime(ticks);
                    return DateTime.Compare(expirationTime, DateTime.Now) < 0;
                }
            }
            catch
            {
                validToken = false;
            }
            return validToken;
        }
        public static long GetUserIDFromToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return 0;
            long userID = 0;
            try
            {
                string key = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                string[] parts = key.Split(new char[] { ':' });
                if (parts.Length == 4)
                {
                    string hash = parts[0];
                    userID = long.Parse(parts[1]);
                    long ticks = long.Parse(parts[3]);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException();
            }
            return userID;
        }
        public static UserType GetUserTypeFromToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return 0;
            int UserType = 0;
            try
            {
                string key = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                string[] parts = key.Split(new char[] { ':' });
                if (parts.Length == 4)
                {
                    string hash = parts[0];
                    var userID = long.Parse(parts[1]);
                    UserType = int.Parse(parts[2]);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException();
            }
            return (UserType)UserType;
        }
        public static string Encrypt(string text)
        {
            string result;
            if (text == "")
            {
                result = "";
            }
            else
            {
                UTF8Encoding uTF8Encoding = new UTF8Encoding();
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(_salt));
                TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                tripleDESCryptoServiceProvider.Key = key;
                tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
                tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
                byte[] bytes = uTF8Encoding.GetBytes(text);
                byte[] inArray;
                try
                {
                    ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
                    inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
                }
                finally
                {
                    tripleDESCryptoServiceProvider.Clear();
                    mD5CryptoServiceProvider.Clear();
                }
                result = Convert.ToBase64String(inArray);
            }
            return result;
        }
        public static string Decrypt(string text)
        {
            string result;
            if (string.IsNullOrEmpty(text))
            {
                result = "";
            }
            else
            {
                UTF8Encoding uTF8Encoding = new UTF8Encoding();
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(_salt));
                TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                tripleDESCryptoServiceProvider.Key = key;
                tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
                tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
                byte[] array = Convert.FromBase64String(text);
                byte[] bytes;
                try
                {
                    ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
                    bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
                }
                catch (Exception ex)
                {
                    bytes = null;
                }
                finally
                {
                    tripleDESCryptoServiceProvider.Clear();
                    mD5CryptoServiceProvider.Clear();
                }
                result = uTF8Encoding.GetString(bytes);
            }
            return result;
        }
        public static bool IsStrongPassword(string password)
        {
            string pattern = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,15}$";
            bool result;
            try
            {
                Regex.Match("", pattern);
            }
            catch (ArgumentException)
            {
                result = false;
                return result;
            }
            result = true;
            return result;
        }
    }

}
