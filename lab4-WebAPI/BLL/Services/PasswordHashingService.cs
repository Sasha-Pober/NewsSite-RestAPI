using System.Security.Cryptography;
using System.Text;

namespace BLL.Services;

public static class PasswordHashingService
{
    public static string GetHashedPassword(string password)
    {
        ArgumentNullException.ThrowIfNull(password);

        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        StringBuilder sb = new StringBuilder();
        foreach (byte b in hash)
        {
            sb.Append(b);
        }
        return sb.ToString();
    }
}
