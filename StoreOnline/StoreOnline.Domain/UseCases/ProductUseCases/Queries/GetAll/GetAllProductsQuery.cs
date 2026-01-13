using Domain.UseCases.ProductUseCases.Models;
using MediatR;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Queries.GetAll;

public class GetAllProductsQuery : IRequest<List<ProductModel>>
{

}
