using Domain.UseCases.ProductUseCases.Abstract;
using FluentValidation;
using MediatR;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.Bind;

public class BindCategoryToProductCommandHandler : IRequestHandler<BindCategoryToProductCommand>
{
    private readonly IProductStorage _productStorage;
    private readonly IValidator<BindCategoryToProductCommand> _validator;

    public BindCategoryToProductCommandHandler(IProductStorage productStorage, IValidator<BindCategoryToProductCommand> validator)
    {
        _productStorage = productStorage;
        _validator = validator;
    }
    public async Task Handle(BindCategoryToProductCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        await _productStorage.BindCategoryToProduct(request.ProductId, request.CategoryId, cancellationToken);
    }
}
