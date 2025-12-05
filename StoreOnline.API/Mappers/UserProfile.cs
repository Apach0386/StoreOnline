using AutoMapper;
using StoreOnline.API.DTOs.Users;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;

namespace StoreOnline.API.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, CreateProductCommand>();
            CreateMap<CreateProductCommand, CreateUserDto>();
        }
    }
}
