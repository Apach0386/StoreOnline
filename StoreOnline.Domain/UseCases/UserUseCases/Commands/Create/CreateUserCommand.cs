using MediatR;

namespace StoreOnline.Domain.UseCases.UserUseCases.Commands.Create;

public class CreateUserCommand : IRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PhoneNumber { get; set; }

    //public List<UserRole>? UserRoles { get; set; }
}
