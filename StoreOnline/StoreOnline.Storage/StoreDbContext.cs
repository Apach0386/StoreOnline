using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using StoreOnline.Storage.Entities;

namespace Storage;

public class StoreDbContext(DbContextOptions<StoreDbContext> options)
    : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>()
            .HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
        builder.Entity<Role>()
            .HasMany(r => r.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

        builder.Entity<Role>()
            .HasData(new Role
            {
                Id = Guid.Parse("d2b5f8f4-3c6e-4f1e-9f3a-1c2b3a4d5e6f"),
                Name = "User",
                NormalizedName = "USER"
            });

        builder.Entity<Role>()
            .HasData(new Role
            {
                Id = Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-e1f2a3b4c5d6"),
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN"

            });

        builder.Entity<ProductCategory>().HasKey(x => new { x.ProductId, x.CategoryId });
    }
}
