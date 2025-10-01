using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using Url_shortener.BLL.Services;
using Url_shortener.DAL.Repositories;
using Urs_shortener.Models.Dtos;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Commands.UpdateUrl;

public class UpdateUrlCommandHandler : IRequestHandler<UpdateUrlCommand, UrlResponceDto>
{
    
    private readonly IUrlRepository _repository;
    private readonly IHashService _hashService;
    private readonly IMapper _mapper;

    public UpdateUrlCommandHandler(IUrlRepository repository, IHashService hashService)
    {
        _repository = repository;
        _hashService = hashService;
    }
    
    public async Task<UrlResponceDto> Handle(UpdateUrlCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.Get(request.Id);

        entity.OriginalUrl = request.Dto.Url;

        if (request.Dto.ChangeUrl)
        {
            var Hash = _hashService.GenerateHash(request.Dto.Url, "gdgdsgs");
            entity.ShortCode = Hash.Substring(0, 8);
        }

        var result =await _repository.Update(entity, request.Id);

        
        return _mapper.Map<UrlResponceDto>(result);;

    }
}