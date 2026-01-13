using MediatR;
using StoreOnline.Domain.UseCases.CategoryUseCases.Abstract;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;

namespace StoreOnline.Domain.UseCases.CategoryUseCases.Queries.GetAll;

public class GetAllCategryQueriesHandler : IRequestHandler<GetAllCategoryQueries, List<CategoryModel>>
{
    private readonly ICategoryStorage _storage;

    public GetAllCategryQueriesHandler(ICategoryStorage storage)
    {
        _storage = storage;
    }
    public async Task<List<CategoryModel>> Handle(GetAllCategoryQueries request, CancellationToken cancellationToken)
    {
        return await _storage.GetAll(request,cancellationToken);
    }
}
