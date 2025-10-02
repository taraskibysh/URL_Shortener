using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Url_shortener.BLL.Configuration;
using Url_shortener.BLL.Services;
using Url_shortener.BLL.Services.HashService;
using Url_shortener.DAL.Repositories;
using Urs_shortener.Models.Dtos;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Commands.UpdateUrl;

public class UpdateUrlCommandHandler : IRequestHandler<UpdateUrlCommand, UrlResponceDto>
{
    
    private readonly IUrlRepository _repository;
    private readonly IHashService _hashService;
    private readonly IMapper _mapper;
    private readonly HashGeneratorOptions _hashOptions;

    public UpdateUrlCommandHandler(IUrlRepository repository, IHashService hashService, IOptions<HashGeneratorOptions> hashOptions)
    {
        _repository = repository;
        _hashService = hashService;
        _hashOptions = hashOptions.Value;
    }
    
    public async Task<UrlResponceDto> Handle(UpdateUrlCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.Get(request.Id);

        if (entity == null)
        {
            throw new KeyNotFoundException("Entity not found");
        }
        
        entity.OriginalUrl = request.Dto.Url;

        if (request.Dto.ChangeUrl)
        {
            var Hash = _hashService.GenerateHash(request.Dto.Url, _hashOptions.Key);
            entity.ShortCode = Hash.Substring(0, 8);
        }

        var result =await _repository.Update(entity, request.Id);

        
        return _mapper.Map<UrlResponceDto>(result);;

    }
}