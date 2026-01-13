using Microsoft.AspNetCore.Identity;

namespace StoreOnline.Storage.Entities;

public class UserRole : IdentityUserRole<Guid>
{
    public User? User { get; set; }
    public Role? Role { get; set; }
}
