using MediatR;

namespace Url_shortener.BLL.Queries.GetRedirect;

public record GetRedirectQuery(string ShortUrl) : IRequest<string>;