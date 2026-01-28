namespace StoreOnline.Domain.Base;

public interface IStorage
{
    Task<bool> IsExists(Guid entityId, CancellationToken cancellationToken);
}
