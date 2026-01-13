using MediatR;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.CreateFromFile;

public class CreateFromFileProductCommand : IRequest
{  
    public required Stream  File { get; set; }
    public required string FileName { get; set; }
}
