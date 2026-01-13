namespace StoreOnline.Domain.Exceptions;

public enum DomainErrorCode
{
    Unauthorized = 401,
    Forbidden = 403,
    BadRequest = 400,
    Gone = 410,
}

