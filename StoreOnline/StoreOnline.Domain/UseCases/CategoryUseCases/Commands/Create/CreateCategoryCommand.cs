using MediatR;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;

namespace StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Create;

public class CreateCategoryCommand : IRequest<CategoryModel>
{
    public required string Name { get; set; }
}
