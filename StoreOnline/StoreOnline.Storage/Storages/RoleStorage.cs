using Microsoft.AspNetCore.Identity;
using StoreOnline.Domain.UseCases.UserUseCases.Abstract;
using StoreOnline.Storage.Entities;

namespace StoreOnline.Storage.Storages;

public class RoleStorage : IRoleStorage
{
    private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;

    public RoleStorage(UserManager<User> userManager )
    {
        _userManager = userManager;
    }
    public async Task AssigneRole(Guid userId, string roleName, CancellationToken cancellationToken)
    {
       var result = await _userManager.AddToRoleAsync((await _userManager.FindByIdAsync(userId.ToString()))!, roleName);
        
        if (!result.Succeeded)
        {
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
        }
    }
}
