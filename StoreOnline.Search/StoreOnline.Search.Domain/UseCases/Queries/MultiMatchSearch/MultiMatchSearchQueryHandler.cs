using MediatR;

namespace StoreOnline.Search.Domain.UseCases.Queries.MultiMatchSearch;

public class MultiMatchSearchQueryHandler : IRequestHandler<MultiMatchSearchQuery, IEnumerable<MultiMatchSearchResultModel>>
{
    private readonly ISearchStorage _storage;

    public MultiMatchSearchQueryHandler(ISearchStorage storage)
    {
        _storage = storage;
    }

    Task<IEnumerable<MultiMatchSearchResultModel>> IRequestHandler<MultiMatchSearchQuery, IEnumerable<MultiMatchSearchResultModel>>.Handle(MultiMatchSearchQuery request, CancellationToken cancellationToken)
    {
        return _storage.SearchMultiMatch(request.Query, cancellationToken);

    }
}
