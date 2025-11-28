using MediatR;
using StoreOnline.Domain.UseCases.CategoryUseCases.Abstract;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;

namespace StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryModel>
{
    private readonly ICategoryStorage _storage;

    public CreateCategoryCommandHandler(ICategoryStorage storage)
    {
        _storage = storage;
    }

    public Task<CategoryModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return _storage.Create(request, cancellationToken);
    }
}
