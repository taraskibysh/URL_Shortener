using AutoMapper;
using Microsoft.AspNetCore.Http;
using Urs_shortener.Models.Dtos;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.MappingProfile;

public class UrlProfile : Profile
{
    public UrlProfile()
    {
        CreateMap<UrlEntry, UrlResponceDto>()
            .ForMember(dest => dest.ShortUrl, opt => opt.MapFrom<ShortUrlResolver>())
            .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.User.UserName));
    }
}

