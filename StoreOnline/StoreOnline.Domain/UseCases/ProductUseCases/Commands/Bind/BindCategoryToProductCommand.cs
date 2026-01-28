using MediatR;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.Bind;

public class BindCategoryToProductCommand : IRequest
{
    public Guid ProductId { get; set; }
    public Guid CategoryId { get; set; }
}
