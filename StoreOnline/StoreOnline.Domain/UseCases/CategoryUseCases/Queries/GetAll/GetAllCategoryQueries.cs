using MediatR;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;

namespace StoreOnline.Domain.UseCases.CategoryUseCases.Queries.GetAll;

public class GetAllCategoryQueries : IRequest<List<CategoryModel>>
{

}
