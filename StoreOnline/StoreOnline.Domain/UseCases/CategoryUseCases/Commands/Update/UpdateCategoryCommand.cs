using MediatR;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;

namespace StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Update;

public class UpdateCategoryCommand : IRequest<CategoryModel>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
