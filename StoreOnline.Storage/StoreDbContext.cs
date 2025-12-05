using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using StoreOnline.Storage.Entities;

namespace Storage;

public class StoreDbContext(DbContextOptions<StoreDbContext> options) 
    : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>,IdentityUserToken<Guid> >(options)
{   
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }  

}
