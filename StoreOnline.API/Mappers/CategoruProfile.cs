using AutoMapper;
using StoreOnline.API.DTOs.Categories;
using StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;

namespace StoreOnline.API.Mappers
{
    public class CategoruProfile : Profile
    {
        public CategoruProfile()
        {
            CreateMap<CreateCategoryDto, CreateCategoryCommand>();
            CreateMap<CategoryDto, CategoryModel>();

        }
    }
}
