using MediatR;
using TrainerHub.Domain.UseCases.BookUseCases.Model;

namespace TrainerHub.Domain.UseCases.BookUseCases.Commands.Create;

public class CreateBookCommand : IRequest<BookModel>
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public int? Year { get; set; }
    public string? Isbn { get; set; }
    public string? Language { get; set; }
}
