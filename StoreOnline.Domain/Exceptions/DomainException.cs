using StoreOnline.Domain.Exceptions;

namespace Domain.Exceptions;

public class DomainException : Exception
{
    public DomainErrorCode ErrorCode { get; set; }
    public DomainException(DomainErrorCode errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }
}
