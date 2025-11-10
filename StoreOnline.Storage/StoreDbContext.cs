using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage;

public class StoreDbContext : DbContext
{ 
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {     
    }

    public DbSet<Product> Products { get; set; }
}
