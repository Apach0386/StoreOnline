using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Storage;
using StoreOnline.Domain.UseCases.UserUseCases.Abstract;
using StoreOnline.Domain.UseCases.UserUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.UserUseCases.Models;
using StoreOnline.Storage.Entities;

namespace StoreOnline.Storage.Storages;

public class UserStorage : IUserStorage
{
    private readonly StoreDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public UserStorage(StoreDbContext dbContext, IMapper mapper, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<UserModel> Create(CreateUserCommand command, CancellationToken cancellationToken)
    {
        User entity = _mapper.Map<User>(command);

        entity.UserName = command.Email;       

        var result = await _userManager.CreateAsync(entity, command.Password);

        if (!result.Succeeded)
        {
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
        }

        return _mapper.Map<UserModel>(entity);
    }
}
