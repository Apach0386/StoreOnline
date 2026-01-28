using Storage.Entities;

namespace StoreOnline.Storage.Entities;

public class Category
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<ProductCategory> ProductCategories { get; set; } = []; // виділяємо пам'ять для списку

}
