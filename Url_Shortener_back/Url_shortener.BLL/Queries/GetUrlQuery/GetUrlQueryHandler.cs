using AutoMapper;
using MediatR;
using Url_shortener.DAL.Repositories;
using Urs_shortener.Models.Dtos;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Queries.GetUrlQuery;

public class GetUrlQueryHandler : IRequestHandler<GetUrlQuery, UrlResponceDto>
{
    private readonly IUrlRepository _repository;
    private readonly IMapper _mapper;

    public GetUrlQueryHandler(IUrlRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UrlResponceDto> Handle(GetUrlQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.Get(request.Id);
        return _mapper.Map<UrlResponceDto>(result);
    }
}