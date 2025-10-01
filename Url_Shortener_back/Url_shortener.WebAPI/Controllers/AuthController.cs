using MediatR;
using Microsoft.AspNetCore.Mvc;
using Url_shortener.BLL.Commands.Auth.Login;
using Url_shortener.BLL.Commands.Auth.Register;
using Urs_shortener.Models.Dtos;

namespace Url_shortener.DAL.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var result = await _mediator.Send(new RegisterCommand(dto));
        
        return Ok(new
        {
            Token = result,
            ExpiresIn = 1800 
        });
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var result = await _mediator.Send(new LoginCommand(dto));
        
            return Ok(new
            {
                Token = result,
                ExpiresIn = 1800 
            });
    }
}
    
