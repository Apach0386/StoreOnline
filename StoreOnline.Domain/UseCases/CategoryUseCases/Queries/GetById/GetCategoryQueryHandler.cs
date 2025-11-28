using MediatR;
using StoreOnline.Domain.UseCases.CategoryUseCases.Abstract;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;

namespace StoreOnline.Domain.UseCases.CategoryUseCases.Queries.GetById;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryModel>
{
    private readonly ICategoryStorage _storage;

    public GetCategoryQueryHandler(ICategoryStorage storage)
    {
        _storage = storage;
    }
    public async Task<CategoryModel> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _storage.GetById(request, cancellationToken);
    }
}
