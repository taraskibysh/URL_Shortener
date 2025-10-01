using MediatR;
using Url_shortener.BLL.Services;
using Url_shortener.DAL.Repositories;

namespace Url_shortener.BLL.Commands.DeleteUrl;

public class DeleteUrlCommandHandler: IRequestHandler<DeleteUrlCommand, long>
{
    private readonly IUrlRepository _repository;

    public DeleteUrlCommandHandler(IUrlRepository repository, IHashService hashService)
    {
        _repository = repository;
    }

    public async Task<long> Handle(DeleteUrlCommand request, CancellationToken cancellationToken)
    {
         await _repository.Delete(request.Id);
        return request.Id;
    }
}