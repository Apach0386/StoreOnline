using Domain.UseCases.ProductUseCases.Abstract;
using MediatR;
using StoreOnline.Domain.Extensions;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductStorage _storage;

    public DeleteProductCommandHandler(IProductStorage storage)
    {
        _storage = storage;
    }
    public async Task Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        await _storage.ThrowIfProductNotFound(command.Id, cancellationToken);

        await _storage.Delete(command, cancellationToken);
    }
}
