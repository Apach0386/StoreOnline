using AutoMapper;
using StoreOnline.Domain.UseCases.UserUseCases.Models;
using StoreOnline.Storage.Entities;

namespace StoreOnline.Storage.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserModel, User>();
        CreateMap<User, UserModel>();
    }
}
