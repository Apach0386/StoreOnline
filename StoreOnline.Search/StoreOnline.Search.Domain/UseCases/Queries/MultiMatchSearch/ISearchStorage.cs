namespace StoreOnline.Search.Domain.UseCases.Queries.MultiMatchSearch;

public interface ISearchStorage
{
    Task<IEnumerable<MultiMatchSearchResultModel>> SearchMultiMatch(string query, CancellationToken cancellationToken);
}
