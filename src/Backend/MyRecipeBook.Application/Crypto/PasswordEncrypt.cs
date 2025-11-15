using System.Security.Cryptography;
using System.Text;

namespace MyRecipeBook.Application.Crypto;

public class PasswordEncrypt
{
    public string Encrypt(string password)
    {
        var additionalKey = "ABC";
        
        var newPassword = $"{password}{additionalKey}";
        
        var bytes = Encoding.UTF8.GetBytes(newPassword);
        var hashBytes = SHA512.HashData(bytes);

        return StringToBytes(hashBytes);
    }
    
    private string StringToBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        
        foreach (byte b in bytes)
        {
            var hex =  b.ToString("x2");
            sb.Append(hex);
        }
        
        return sb.ToString();
        
    }
}