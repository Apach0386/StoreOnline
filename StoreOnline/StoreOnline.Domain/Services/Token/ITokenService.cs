using StoreOnline.Domain.UseCases.UserUseCases.Models;

namespace StoreOnline.Domain.Services.Token;

public interface ITokenService
{
    string GetToken(UserModel model);
}
