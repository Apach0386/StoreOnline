using StoreOnline.Domain.UseCases.UserUseCases.Models;

namespace StoreOnline.Domain.UseCases.UserUseCases.Abstract;

public interface ILoginUserStorage
{
    Task<UserModel> LoginUser (string phoneNumber, string password, CancellationToken cancellationToken);
}
