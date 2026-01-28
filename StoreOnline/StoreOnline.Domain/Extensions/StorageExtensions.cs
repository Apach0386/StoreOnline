using Domain.UseCases.ProductUseCases.Abstract;
using StoreOnline.Domain.Exceptions.Product;

namespace StoreOnline.Domain.Extensions;

public static class StorageExtensions
{
    public static async Task ThrowIfProductNotFound(this IProductStorage storage, Guid id, CancellationToken cancellationToken)
    {
        if (!await storage.IsExists(id, cancellationToken))
        {
            throw new ProductNotFoundException(id);
        }
    }
}
