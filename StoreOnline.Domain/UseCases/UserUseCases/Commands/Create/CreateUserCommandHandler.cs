using MediatR;
using StoreOnline.Domain.UseCases.UserUseCases.Abstract;
using StoreOnline.Domain.UseCases.UserUseCases.Models;

namespace StoreOnline.Domain.UseCases.UserUseCases.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserModel>
{
    private readonly IUserStorage _storage;

    public CreateUserCommandHandler(IUserStorage storage)
    {
        _storage = storage;
    }
    public Task<UserModel> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        return _storage.Create(command, cancellationToken);
    }
}
