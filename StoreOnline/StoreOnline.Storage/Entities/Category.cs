using Storage.Entities;

namespace StoreOnline.Storage.Entities;

public class Category
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<Product>? Products { get; set; }

}
