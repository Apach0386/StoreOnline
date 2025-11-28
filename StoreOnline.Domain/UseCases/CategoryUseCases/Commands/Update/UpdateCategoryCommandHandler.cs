using MediatR;
using StoreOnline.Domain.UseCases.CategoryUseCases.Abstract;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;

namespace StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Update;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryModel>
{
    private readonly ICategoryStorage _storage;

    public UpdateCategoryCommandHandler(ICategoryStorage storage)
    {
        _storage = storage;
    }
    public async Task<CategoryModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _storage.Update(request, cancellationToken);
    }
}
