namespace Url_shortener.BLL.Services;

public interface IHashService
{
    public string GenerateHash(string data, string key);
}