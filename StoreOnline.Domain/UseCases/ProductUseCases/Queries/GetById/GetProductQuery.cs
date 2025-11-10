using Domain.UseCases.ProductUseCases.Models;
using MediatR;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Queries.GetById;

public class GetProductQuery : IRequest<ProductModel>
{
    public Guid Id { get; set; }

}
