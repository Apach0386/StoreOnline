using MediatR;

namespace StoreOnline.Search.Domain.UseCases.Queries.MultiMatchSearch;

public class MultiMatchSearchQuery : IRequest<IEnumerable<MultiMatchSearchResultModel>>
{
    public string Query { get; set; } = null!;
}
