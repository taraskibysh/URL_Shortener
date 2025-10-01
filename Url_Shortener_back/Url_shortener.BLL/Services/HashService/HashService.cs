using System.Security.Cryptography;
using System.Text;

namespace Url_shortener.BLL.Services.HashService;

public class HashService: IHashService
{
    public string GenerateHash(string data, string key)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        return Convert.ToBase64String(hashBytes); 
    }
    
}