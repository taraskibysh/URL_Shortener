using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Url_shortener.BLL.Commands.CreateUrl;

namespace Url_shortener.DAL.Controllers 
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UrlController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> CreateUrl([FromBody] string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return BadRequest("URL cannot be empty.");

            var result = await _mediator.Send(new CreateUrlCommand(url));
            return Ok(result);
        }
    }
}