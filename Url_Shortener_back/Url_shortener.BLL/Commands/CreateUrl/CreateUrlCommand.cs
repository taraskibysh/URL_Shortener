using MediatR;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Commands.CreateUrl;

public record CreateUrlCommand(string Url) : IRequest<UrlEntry>;
