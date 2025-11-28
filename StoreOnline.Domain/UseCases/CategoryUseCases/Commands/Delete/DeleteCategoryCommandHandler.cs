using MediatR;
using StoreOnline.Domain.UseCases.CategoryUseCases.Abstract;

namespace StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryStorage _storage;

    public DeleteCategoryCommandHandler(ICategoryStorage storage)
    {
        _storage = storage;
    }
    public async Task Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        await _storage.Delete(command, cancellationToken);
    }
}
