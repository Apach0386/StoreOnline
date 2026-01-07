namespace Storage.Entities;

public class Book
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public  required string Author { get; set; }
    public int? Yaer { get; set; }
    public string? Isbn { get; set; }
    public string? Language { get; set; }
}
