using AutoMapper;
using Domain.UseCases.ProductUseCases.Models;
using Storage.Entities;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;

namespace Storage.Mappers;

public class ProductProfile : Profile
{   
    public ProductProfile()
    {
        CreateMap<CreateProductCommand, Product>();
        CreateMap<Product, ProductModel>();
        CreateMap<ProductModel, Product>();
    }
}
