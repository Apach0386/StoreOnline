using StoreOnline.Storage.Entities;

namespace Storage.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; } 
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public List<ProductCategory> ProductCategories { get; set; } = []; // виділяємо пам'ять для списку

}
