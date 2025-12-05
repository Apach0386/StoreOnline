using StoreOnline.Storage.Entities;

namespace StoreOnline.API.DTOs.Users
{
    public class CreateUserDto
    {
        public required string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

        //public List<UserRole>? UserRoles { get; set; }
    }
}
