using MediatR;

namespace StoreOnline.Search.Domain.UseCases.Commands.Index;

public class IndexCommandHandler : IRequestHandler<IndexCommand>
{
    private readonly IIndexStorage _storage;

    public IndexCommandHandler(IIndexStorage storage)
    {
        _storage = storage;
    }
    public async Task Handle(IndexCommand command, CancellationToken cancellationToken)
    {
        await _storage.IndexProduct(command.Id, command.Name, command.Description, cancellationToken);
    }
}
