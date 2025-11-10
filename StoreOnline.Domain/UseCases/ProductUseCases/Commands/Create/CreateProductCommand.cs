using Domain.UseCases.ProductUseCases.Models;
using MediatR;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;

public class CreateProductCommand : IRequest<ProductModel>
{   
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
