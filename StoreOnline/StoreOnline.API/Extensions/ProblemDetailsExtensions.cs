using Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoreOnline.Domain.Exceptions;

namespace StoreOnline.API.Extesions
{
    
    public static class ProblemDetailsExtensions
    {
        public static ProblemDetails CreateFrom(this ProblemDetailsFactory factory,
           HttpContext context,
           DomainException domainException) =>
           factory.CreateProblemDetails(context,
               domainException.ErrorCode switch
               {
                   DomainErrorCode.Gone => StatusCodes.Status410Gone,
                   DomainErrorCode.Unauthorized => StatusCodes.Status401Unauthorized,
                   DomainErrorCode.Forbidden => StatusCodes.Status403Forbidden,
                   DomainErrorCode.BadRequest => StatusCodes.Status400BadRequest,
                   _ => StatusCodes.Status500InternalServerError
               },
               "Oops :((",
               detail: domainException.Message);

        public static ProblemDetails CreateFrom(this ProblemDetailsFactory factory,
            HttpContext context,
            ValidationException validationException)
        {
            var model = new ModelStateDictionary();

            foreach (var error in validationException.Errors)
            {
                model.AddModelError(error.PropertyName, error.ErrorCode);
            }

            return factory.CreateValidationProblemDetails(context, model, StatusCodes.Status400BadRequest);
        }
    }
}
