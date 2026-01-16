using OpenSearch.Client;
using StoreOnline.Search.Domain.UseCases.Queries.MultiMatchSearch;
using StoreOnline.Search.Storage.Entities;

namespace StoreOnline.Search.Storage.Storages;

public class SearchStorage : ISearchStorage
{
    private readonly IOpenSearchClient _searchClient;

    public SearchStorage(IOpenSearchClient searchClient)
    {
        _searchClient = searchClient;
    }

    public async Task<IEnumerable<MultiMatchSearchResultModel>> SearchMultiMatch(string query, CancellationToken cancellationToken)
    {
        var result = await _searchClient.SearchAsync<SearchProductEntity>(s => s
            .Query(q => q
                .MultiMatch(m => m
                    .Fields(f => f
                        .Field(ff => ff.Name, 2)
                        .Field(ff => ff.Description))
                    .Query(query).Fuzziness(Fuzziness.EditDistance(2))))
            .Size(50)
            .Source(src => src.Includes(x => x.Fields(p => p.Id).Fields(p => p.Name).Fields(p => p.Description))), cancellationToken);

        return result.Hits.Select(x => new MultiMatchSearchResultModel
        {
            ProductId = x.Source.Id,
            Name = x.Source.Name,
            Description = x.Source.Description,
            Score = (int)(x.Score ?? 0)                        
        });
    }
}
