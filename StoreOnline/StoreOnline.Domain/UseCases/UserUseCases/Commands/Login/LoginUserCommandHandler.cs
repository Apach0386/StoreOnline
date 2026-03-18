using MediatR;
using StoreOnline.Domain.UseCases.UserUseCases.Abstract;

namespace StoreOnline.Domain.UseCases.UserUseCases.Commands.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly ILoginUserStorage _storage;

    public LoginUserCommandHandler(ILoginUserStorage storage)
    {
        _storage = storage;
    }
    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var res = await _storage.LoginUser(request.PhoneNumber, request.Password, cancellationToken);


    }
}
