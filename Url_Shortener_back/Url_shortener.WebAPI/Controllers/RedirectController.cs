using MediatR;
using Microsoft.AspNetCore.Mvc;
using Url_shortener.BLL.Queries.GetRedirect;

namespace Url_shortener.DAL.Controllers;


[ApiController]
[Route("")]
public class RedirectController : ControllerBase
{
    private readonly IMediator _mediator;

    public RedirectController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("{code}")]
    public async Task<IActionResult> RedirectToUrl(string code)
    {
        var result = await _mediator.Send(new GetRedirectQuery(code));
        return Redirect(result);
    }
}