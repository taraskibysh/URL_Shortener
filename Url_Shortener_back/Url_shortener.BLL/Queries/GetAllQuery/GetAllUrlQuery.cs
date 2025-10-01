using MediatR;
using Urs_shortener.Models.Dtos;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Queries.GetAllQuery;

public class GetAllUrlQuery(): IRequest<List<UrlResponceDto>>;