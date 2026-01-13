using MediatR;
using StoreOnline.Domain.UseCases.UserUseCases.Abstract;

namespace StoreOnline.Domain.UseCases.UserUseCases.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserStorage _storage;
    private readonly IRoleStorage _roleStorage;

    public CreateUserCommandHandler(IUserStorage storage, IRoleStorage roleStorage)
    {
        _storage = storage;
        _roleStorage = roleStorage;
    }
    public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _storage.Create(command, cancellationToken);

        await _roleStorage.AssigneRole(user.Id, "User", cancellationToken);

    }
}
