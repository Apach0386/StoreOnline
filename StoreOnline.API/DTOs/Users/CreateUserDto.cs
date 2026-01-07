using StoreOnline.Storage.Entities;

namespace StoreOnline.API.DTOs.Users
{
    public class CreateUserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }

        //public List<UserRole>? UserRoles { get; set; }
    }
}
