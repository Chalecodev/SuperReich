using System.Security.Cryptography;
using System.Text;

namespace SuperReich.Application.Helper
{
    public static class Encryptor
    {
        public static string EncryptPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new();

            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInput = EncryptPassword(password);
            return StringComparer.OrdinalIgnoreCase.Compare(hashedInput, hashedPassword) == 0;
        }
    }
}
