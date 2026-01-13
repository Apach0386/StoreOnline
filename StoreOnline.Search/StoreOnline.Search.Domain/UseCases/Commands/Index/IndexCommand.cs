using MediatR;

namespace StoreOnline.Search.Domain.UseCases.Commands.Index;

public class IndexCommand : IRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
