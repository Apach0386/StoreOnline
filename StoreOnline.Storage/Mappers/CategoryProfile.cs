using AutoMapper;
using StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;
using StoreOnline.Storage.Entities;

namespace StoreOnline.Storage.Mappers;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        //CreateMap<Category, CreateCategoryCommand>();
        //CreateMap<CategoryModel, Category>();
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<Category, CategoryModel>();

    }
}
