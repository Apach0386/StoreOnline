using Microsoft.AspNetCore.Identity;

namespace StoreOnline.Storage.Entities;

public class User : IdentityUser<Guid>
{    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }    
    public DateTimeOffset DateOfBirth { get; set; }

    public List<UserRole>? UserRoles { get; set; }
}
