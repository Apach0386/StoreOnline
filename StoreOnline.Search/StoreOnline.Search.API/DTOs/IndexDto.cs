namespace StoreOnline.Search.API.DTOs
{
    public class IndexDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
