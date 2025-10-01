using AutoMapper;
using Microsoft.AspNetCore.Http;
using Urs_shortener.Models.Dtos;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.MappingProfile;

public class ShortUrlResolver : IValueResolver<UrlEntry, UrlResponceDto, string>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ShortUrlResolver(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string Resolve(UrlEntry source, UrlResponceDto destination, string destMember, ResolutionContext context)
    {
        var request = _httpContextAccessor.HttpContext!.Request;
        var baseUrl = $"{request.Scheme}://{request.Host}";
        return $"{baseUrl}/{source.ShortCode}";
    }
}
