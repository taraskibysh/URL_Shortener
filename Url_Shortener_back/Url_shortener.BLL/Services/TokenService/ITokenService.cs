using System.Security.Claims;

namespace Url_shortener.BLL.Services.AuthService;

public interface ITokenService
{
    public string GenerateToken(IEnumerable<Claim> userClaims);
}