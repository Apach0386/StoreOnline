using Domain.UseCases.ProductUseCases.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.Update;

public class UpdateProductCommand : IRequest<ProductModel>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
