using MediatR;
using Url_shortener.BLL.Services;
using Url_shortener.DAL.Repositories;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Commands.CreateUrl;

public class CreateUrlCommandHandler : IRequestHandler<CreateUrlCommand, UrlEntry>
{
    private readonly IUrlRepository _repository;
    private readonly IHashService _hashService;

    public CreateUrlCommandHandler(IUrlRepository repository, IHashService hashService)
    {
        _repository = repository;
        _hashService = hashService;
    }
    public async Task<UrlEntry> Handle(CreateUrlCommand request, CancellationToken cancellationToken)
    {
        
        var Hash = _hashService.GenerateHash(request.Url, "gdgdsgs");
        var newUrl = new UrlEntry
        {
            OriginalUrl = request.Url,
            ShortCode = Hash.Substring(0,8)
            
            
        };

        var result = await _repository.Create(newUrl);
        return await Task.FromResult(result);
    }
    
}
