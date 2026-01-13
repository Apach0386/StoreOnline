using StoreOnline.Domain.UseCases.UserUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.UserUseCases.Models;

namespace StoreOnline.Domain.UseCases.UserUseCases.Abstract;

public interface IUserStorage
{
    Task<UserModel> Create(CreateUserCommand command, CancellationToken cancellationToken);
}
