using MediatR;
using Urs_shortener.Models.Dtos;

namespace Url_shortener.BLL.Commands.Auth.Register;

public record RegisterCommand(RegisterDto Dto) : IRequest<string>;