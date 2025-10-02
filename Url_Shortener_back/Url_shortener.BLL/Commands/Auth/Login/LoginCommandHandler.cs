using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Url_shortener.BLL.Services.TokenService;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Commands.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(UserManager<ApplicationUser> manager, ITokenService tokenService)
    {
        _userManager = manager;
        _tokenService = tokenService;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var model = request.Dto;

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
           throw new InvalidOperationException($"User with email {model.Email} not found.");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);

        if (!isPasswordValid)
        {
            throw new ArgumentException("Wrong password or email"); 
        }

        var customClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>(customClaims) 
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
        };
        
        authClaims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var tokenString = _tokenService.GenerateToken(authClaims);

        return tokenString;
    }
}