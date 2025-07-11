using System.Security.Cryptography;
using System.Text;

namespace BackendApi.Tools
{
    public static class EncodeDecodeJson
    {
        public static string EncryptJson(string json, string key)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));
            aes.GenerateIV();

            var encryptor = aes.CreateEncryptor();
            var jsonBytes = Encoding.UTF8.GetBytes(json);
            var encryptedBytes = encryptor.TransformFinalBlock(jsonBytes, 0, jsonBytes.Length);

            var result = aes.IV.Concat(encryptedBytes).ToArray();
            return Convert.ToBase64String(result);
        }

        public static string DecryptJson(string encryptedBase64, string key)
        {
            string base64 = encryptedBase64.Replace("-", "+").Replace("_", "/");
            int padding = 4 - (base64.Length % 4);
            if (padding < 4) base64 += new string('=', padding);

            var fullBytes = Convert.FromBase64String(base64);
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));
            aes.IV = fullBytes.Take(16).ToArray();

            var encryptedBytes = fullBytes.Skip(16).ToArray();
            var decryptor = aes.CreateDecryptor();
            var decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(decryptedBytes);
        }

        public static string ToUrlSafeBase64(string base64)
        {
            return base64.Replace("+", "-").Replace("/", "_").Replace("=", "");
        }



    }
}
