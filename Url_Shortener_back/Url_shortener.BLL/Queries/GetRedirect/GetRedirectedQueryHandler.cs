using MediatR;
using Url_shortener.DAL.Repositories;

namespace Url_shortener.BLL.Queries.GetRedirect;

public class GetRedirectedQueryHandler : IRequestHandler<GetRedirectQuery, string>
{
    private readonly IUrlRepository _repository;

    public GetRedirectedQueryHandler(IUrlRepository repository)
    {
        _repository = repository;
    }
    public async Task<string> Handle(GetRedirectQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByShortCode(request.ShortUrl);
        return result.OriginalUrl;
    }
}