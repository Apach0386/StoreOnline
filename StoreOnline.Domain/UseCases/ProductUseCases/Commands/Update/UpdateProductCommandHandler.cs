using Domain.UseCases.ProductUseCases.Abstract;
using Domain.UseCases.ProductUseCases.Models;
using MediatR;
using StoreOnline.Domain.Base;
using StoreOnline.Domain.Extensions;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductModel>
{
    private readonly IProductStorage _productStorage;

    public UpdateProductCommandHandler(IProductStorage productStorage)
    {
        _productStorage = productStorage;
    }
    public async  Task<ProductModel> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        await _productStorage.ThrowIfProductNotFound(command.Id, cancellationToken);

        return await _productStorage.Update(command, cancellationToken);
    }
}
