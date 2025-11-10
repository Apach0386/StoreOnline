using API.StoreOnline.DTOs.Products;
using AutoMapper;
using Domain.UseCases.ProductUseCases.Models;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Update;

namespace API.StoreOnline.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
           
            CreateMap<ProductModel, ProductDto>();
            CreateMap<ProductDto, ProductModel>();            
           
            CreateMap<CreateProductDto, CreateProductCommand>();

            CreateMap<UpdateProductDto, UpdateProductDto>();

            CreateMap<List<ProductModel>, List<ProductDto>>();
            

        }
    }
}
