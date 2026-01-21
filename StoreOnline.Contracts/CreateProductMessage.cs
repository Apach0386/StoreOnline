namespace StoreOnline.Contracts;

public class CreateProductMessage
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? ActivityId { get; set; } 
}
