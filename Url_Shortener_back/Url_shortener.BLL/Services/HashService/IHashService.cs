namespace Url_shortener.BLL.Services.HashService;

public interface IHashService
{
    public string GenerateHash(string data, string key);
}