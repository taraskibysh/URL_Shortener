using MediatR;
using Urs_shortener.Models.Dtos;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Commands.UpdateUrl;

public record UpdateUrlCommand(UpdateUrlDto Dto, long Id) : IRequest<UrlResponceDto>;