using Domain.UseCases.ProductUseCases.Abstract;
using Domain.UseCases.ProductUseCases.Models;
using MediatR;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductModel>
{
    private readonly IProductStorage _storage;

    public CreateProductCommandHandler(IProductStorage storage)
    {
        _storage = storage;
    }
    public Task<ProductModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
       return _storage.Create(request, cancellationToken);
    }
}