using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Url_shortener.BLL.Commands.CreateUrl;
using Url_shortener.BLL.Commands.DeleteUrl;
using Url_shortener.BLL.Commands.UpdateUrl;
using Url_shortener.BLL.Queries.GetAllQuery;
using Url_shortener.BLL.Queries.GetUrlQuery;
using Urs_shortener.Models.Dtos;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUrl(long id)
        {
            var result = await _mediator.Send( new GetUrlQuery(id));
            return Ok(result);
        }
        
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send( new GetAllUrlQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUrl([FromBody] string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return BadRequest("URL cannot be empty.");

            var result = await _mediator.Send(new CreateUrlCommand(url));
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUrl([FromBody] UpdateUrlDto dto, long id)
        {
            var result = await _mediator.Send(new UpdateUrlCommand(dto, id ));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result =  await _mediator.Send(new DeleteUrlCommand(id));
            return Ok(result);
        }
    }
}