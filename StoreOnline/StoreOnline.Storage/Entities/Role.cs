using Microsoft.AspNetCore.Identity;

namespace StoreOnline.Storage.Entities;

public class Role : IdentityRole<Guid>
{
    public List<UserRole>? UserRoles { get; set; }
}