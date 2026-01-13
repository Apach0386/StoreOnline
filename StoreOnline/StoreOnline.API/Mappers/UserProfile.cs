using AutoMapper;
using StoreOnline.API.DTOs.Users;
using StoreOnline.Domain.UseCases.UserUseCases.Commands.Create;

namespace StoreOnline.API.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, CreateUserCommand>();
            CreateMap<CreateUserCommand, CreateUserDto>();
        }
    }
}
