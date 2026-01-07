using TrainerHub.Domain.UseCases.BookUseCases.Commands.Create;
using TrainerHub.Domain.UseCases.BookUseCases.Model;

namespace TrainerHub.Domain.UseCases.BookUseCases.Abstract;

public interface IBookStorage
{
    
    Task<BookModel> CreateBook(CreateBookCommand command, CancellationToken cancellationToken); 
}
