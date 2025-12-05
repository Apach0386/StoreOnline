using MediatR;
using StoreOnline.Domain.UseCases.UserUseCases.Models;

namespace StoreOnline.Domain.UseCases.UserUseCases.Commands.Create;

public class CreateUserCommand : IRequest<UserModel>
{
    public required string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }

    //public List<UserRole>? UserRoles { get; set; }
}
