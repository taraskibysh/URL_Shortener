using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Url_shortener.BLL.Services;
using Url_shortener.BLL.Services.TokenService;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Commands.Auth.Register;

public class RegisterCommandHandler: IRequestHandler<RegisterCommand, string>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;

    public RegisterCommandHandler(UserManager<ApplicationUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var model = request.Dto;

        var userExists = await _userManager.FindByEmailAsync(model.Email);
        if (userExists != null)
        {
            throw new ArgumentException("User with this email already exist");
        }
        
        var user = new ApplicationUser
        {
            UserName = model.Username,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            var errorMessage = string.Join(", ", errors);
            
            throw new ArgumentException($"Registration error: {errorMessage}");
        }

        await _userManager.AddToRoleAsync(user, "User");

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, "User")
        };

        var tokenString = _tokenService.GenerateToken(authClaims);

        return tokenString;
    }
}