using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Url_shortener.BLL.Configuration;
using Url_shortener.BLL.Services;
using Url_shortener.DAL.Repositories;
using Urs_shortener.Models.Dtos;
using Urs_shortener.Models.Models;

namespace Url_shortener.BLL.Commands.CreateUrl;

public class CreateUrlCommandHandler : IRequestHandler<CreateUrlCommand, UrlResponceDto>
{
    private readonly IUrlRepository _repository;
    private readonly IHashService _hashService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly HashGeneratorOptions _hashOptions;
    private readonly IMapper _mapper;

    public CreateUrlCommandHandler(
        IUrlRepository repository, 
        IHashService hashService, 
        UserManager<ApplicationUser> manager,
        IHttpContextAccessor httpContextAccessor,
        IOptions<HashGeneratorOptions> hashOptions,
        IMapper mapper)
    {
        _repository = repository;
        _hashService = hashService;
        _userManager = manager;
        _httpContextAccessor = httpContextAccessor;
        _hashOptions = hashOptions.Value;
        _mapper = mapper;
    }

    public async Task<UrlResponceDto> Handle(CreateUrlCommand request, CancellationToken cancellationToken)
    {
        var hash = _hashService.GenerateHash(request.Url, _hashOptions.Key);

        var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext!.User);
        if (userId == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        var newUrl = new UrlEntry
        {
            OriginalUrl = request.Url,
            ShortCode = hash.Substring(0, 8),
            UserId = userId
        };

        var result = await _repository.Create(newUrl);
        return _mapper.Map<UrlResponceDto>(result);
    }
}