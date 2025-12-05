using AutoMapper;
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

    public UserStorage(StoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<UserModel> Create(CreateUserCommand command, CancellationToken cancellationToken)
    {
        User entity = _mapper.Map<User>(command);

        await _dbContext.Users.AddAsync(entity, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        var res = await _dbContext.Users
            .AsNoTracking()
            .FirstAsync(x => x.Id == entity.Id, cancellationToken);
        
        return _mapper.Map<UserModel>(res);


    }
}
