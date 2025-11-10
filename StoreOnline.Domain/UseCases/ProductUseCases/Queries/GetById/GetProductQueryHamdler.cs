using Domain.UseCases.ProductUseCases.Abstract;
using Domain.UseCases.ProductUseCases.Models;
using MediatR;
using System.Collections.Concurrent;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Queries.GetById;

public class GetProductQueryHamdler : IRequestHandler<GetProductQuery, ProductModel>
{
    private readonly IProductStorage _storage;

    public GetProductQueryHamdler(IProductStorage storage)
    {
        _storage = storage;
    }
    public Task<ProductModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
       return _storage.GetById(request, cancellationToken);
    }
}
