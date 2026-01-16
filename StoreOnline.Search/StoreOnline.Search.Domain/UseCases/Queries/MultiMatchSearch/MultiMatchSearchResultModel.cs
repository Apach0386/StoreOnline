using StoreOnline.Search.Domain.UseCases.Commands.Index;

namespace StoreOnline.Search.Domain.UseCases.Queries.MultiMatchSearch;

public class MultiMatchSearchResultModel
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public double Score { get; set; }

}
