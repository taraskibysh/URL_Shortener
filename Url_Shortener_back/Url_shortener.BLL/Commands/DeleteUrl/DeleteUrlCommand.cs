using MediatR;

namespace Url_shortener.BLL.Commands.DeleteUrl;

public record DeleteUrlCommand(long Id) : IRequest<long>;