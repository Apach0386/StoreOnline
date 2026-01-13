using MediatR;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;

namespace StoreOnline.Domain.UseCases.CategoryUseCases.Queries.GetById;

public class GetCategoryQuery : IRequest<CategoryModel>
{
    public required Guid Id { get; set; }
}
