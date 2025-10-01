using MediatR;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Commands.UpdateUrl;

public record UpdateUrlCommand() : IRequest<UrlEntry>;