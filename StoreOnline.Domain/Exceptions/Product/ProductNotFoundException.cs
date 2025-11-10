using Domain.Exceptions;

namespace StoreOnline.Domain.Exceptions.Product;

public class ProductNotFoundException : DomainException
{
    public ProductNotFoundException(Guid addressId)
        : base(DomainErrorCode.Gone, $"Product with id {addressId} was not found")
    {

    }
}
