using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Url_shortener.BLL.Services.AuthService;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(IEnumerable<Claim> userClaims)
    {
        var jwtKey = _configuration["Jwt:Key"] 
                     ?? throw new InvalidOperationException("Jwt:Key is not configured.");
        var issuer = _configuration["Jwt:Issuer"] 
                     ?? throw new InvalidOperationException("Jwt:Issuer is not configured.");
        var audience = _configuration["Jwt:Audience"] 
                       ?? throw new InvalidOperationException("Jwt:Audience is not configured.");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(userClaims),
            Expires = DateTime.UtcNow.AddMinutes(30), 
            SigningCredentials = credentials,
            Issuer = issuer,
            Audience = audience
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}