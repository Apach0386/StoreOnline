namespace StoreOnline.API.DTOs.Users
{
    public class LoginUserDto
    {
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
    }
}
