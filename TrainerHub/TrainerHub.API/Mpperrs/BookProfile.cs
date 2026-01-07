using API.TrainerHub.DTOs.Book;
using AutoMapper;
using TrainerHub.Domain.UseCases.BookUseCases.Commands.Create;

namespace TrainerHub.API.Mpperrs
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, CreateBookCommand>();
        }
    }
}
