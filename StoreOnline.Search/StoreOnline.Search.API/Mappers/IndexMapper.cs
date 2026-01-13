using AutoMapper;
using StoreOnline.Search.API.DTOs;
using StoreOnline.Search.Domain.UseCases.Commands.Index;

namespace StoreOnline.Search.API.Mappers
{
    public class IndexMapper : Profile
    {
        public IndexMapper()
        {
            CreateMap<IndexDto, IndexCommand>();
        }
    }
}
