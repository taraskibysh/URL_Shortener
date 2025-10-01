using MediatR;
using Urs_shortener.Models.Dtos;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Queries.GetUrlQuery;

public record GetUrlQuery(long Id) : IRequest<UrlResponceDto>; 
