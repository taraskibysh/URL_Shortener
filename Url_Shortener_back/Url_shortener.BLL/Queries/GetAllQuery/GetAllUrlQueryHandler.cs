using AutoMapper;
using MediatR;
using Url_shortener.DAL.Repositories;
using Urs_shortener.Models.Dtos;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Queries.GetAllQuery;

public class GetAllUrlQueryHandler : IRequestHandler<GetAllUrlQuery, List<UrlResponceDto>>
{
    private readonly IUrlRepository _repository;
    private readonly IMapper _mapper;

    public GetAllUrlQueryHandler(IUrlRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<UrlResponceDto>> Handle(GetAllUrlQuery request, CancellationToken cancellationToken)
    {
        var result =  await _repository.GetAll();

        return _mapper.Map<List<UrlResponceDto>>(result);

    }
}