using OpenSearch.Client;
using StoreOnline.Search.Domain.UseCases.Commands.Index;
using StoreOnline.Search.Storage.Entities;

namespace StoreOnline.Search.Storage.Storages;

public class IndexStorage : IIndexStorage
{
    private readonly IOpenSearchClient _searchClient;

    public IndexStorage(IOpenSearchClient searchClient)
    {
        _searchClient = searchClient;
    }

    public async Task IndexProduct(Guid productId, string name, string? description, CancellationToken cancellationToken) 
    {
        await _searchClient.IndexAsync(new SearchProductEntity
        {
            Id = productId,
            Name = name,
            Description = description
        }, idx => idx.Index("storeonline-products"), cancellationToken);
    }
}
