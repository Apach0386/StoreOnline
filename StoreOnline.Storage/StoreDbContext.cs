using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using StoreOnline.Storage.Entities;

namespace Storage;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

}
