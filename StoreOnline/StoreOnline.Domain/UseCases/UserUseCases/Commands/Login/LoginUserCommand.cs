using MediatR;

namespace StoreOnline.Domain.UseCases.UserUseCases.Commands.Login;

public class LoginUserCommand : IRequest<string>
{
    public required string  PhoneNumber { get; set; }
    public required string Password { get; set; }
}
