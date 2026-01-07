namespace TrainerHub.Domain.UseCases.BookUseCases.Model;

public class BookModel
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public int? Year { get; set; }
    public string? Isbn { get; set; }
    public string? Language { get; set; }
}
