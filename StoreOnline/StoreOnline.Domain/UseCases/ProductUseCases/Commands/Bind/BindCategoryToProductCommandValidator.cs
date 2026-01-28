using Domain.UseCases.ProductUseCases.Abstract;
using FluentValidation;
using StoreOnline.Domain.UseCases.CategoryUseCases.Abstract;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.Bind;

public class BindCategoryToProductCommandValidator : AbstractValidator<BindCategoryToProductCommand>
{
    

    public BindCategoryToProductCommandValidator(IProductStorage productStorage, ICategoryStorage categoryStorage)
    {       
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("ProductId cannot be empty.")
            .MustAsync(productStorage.IsExists)
            .WithMessage("Product not found.");
        
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("CategoryId cannot be empty.")
            .MustAsync(categoryStorage.IsExists)
            .WithMessage("Category not found.");

        RuleFor(x => x)
            .MustAsync(async (command, cancellationToken) =>
            {
                return !await productStorage.IsBindExists(command.ProductId, command.CategoryId, cancellationToken);
                
            })
            .WithMessage("The category is already bound to the product.");
    }
}
