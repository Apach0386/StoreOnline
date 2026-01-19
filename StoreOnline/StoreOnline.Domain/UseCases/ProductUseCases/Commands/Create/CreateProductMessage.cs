namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;

public class CreateProductMessage
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
