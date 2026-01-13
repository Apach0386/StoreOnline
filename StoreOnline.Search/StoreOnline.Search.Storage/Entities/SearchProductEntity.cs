namespace StoreOnline.Search.Storage.Entities;

public class SearchProductEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
