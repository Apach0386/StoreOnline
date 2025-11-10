using Domain.UseCases.ProductUseCases.Abstract;
using Domain.UseCases.ProductUseCases.Models;
using MediatR;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Queries.GetAll;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductModel>>
{
    private readonly IProductStorage _storage;

    public GetAllProductsQueryHandler(IProductStorage storage)
    {
        _storage = storage;
    }
    public Task<List<ProductModel>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
       return  _storage.GetAll(query, cancellationToken);
    }
}
