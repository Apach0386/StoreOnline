using MediatR;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.Delete;

public class DeleteProductCommand : IRequest
{
    public Guid Id { get; set; }
}
