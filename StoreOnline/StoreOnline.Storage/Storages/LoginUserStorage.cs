using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Storage;
using StoreOnline.Domain.UseCases.UserUseCases.Abstract;
using StoreOnline.Domain.UseCases.UserUseCases.Models;
using StoreOnline.Storage.Entities;

namespace StoreOnline.Storage.Storages;

public class LoginUserStorage : ILoginUserStorage
{
    private readonly StoreDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public LoginUserStorage(StoreDbContext dbContext, IMapper mapper, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<UserModel> LoginUser(string phoneNumber, string password, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber, cancellationToken);

        if (user == null)
        {
            throw new Exception("User not found.");
        };

        if (await _userManager.IsLockedOutAsync(user))
        {
            throw new Exception("Account is locked.");

        }

        var result = await _userManager.CheckPasswordAsync(user, password);

        if (result == false)
        {
            await _userManager.AccessFailedAsync(user);

            throw new Exception("Invalid phone or password.");
        }

        await _userManager.ResetAccessFailedCountAsync(user);

        var userModel = _mapper.Map<UserModel>(user);

        return userModel;
    }
}
