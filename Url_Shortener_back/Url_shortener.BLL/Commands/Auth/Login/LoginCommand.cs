using MediatR;
using Urs_shortener.Models.Dtos;

namespace Url_shortener.BLL.Commands.Auth.Login;

public record LoginCommand(LoginDto Dto) : IRequest<string>;