using Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using StoreOnline.API.Extesions;

namespace StoreOnline.API.MiddleWares
{
    public class ErrorMiddleWare //: IMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleWare> _logger;
        private readonly ProblemDetailsFactory _problemDetailsFactory;

        public ErrorMiddleWare(RequestDelegate next, ILogger<ErrorMiddleWare> logger, ProblemDetailsFactory problemDetailsFactory)
        {
            _next = next;
            _logger = logger;
            _problemDetailsFactory = problemDetailsFactory;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);

            }
            catch (Exception exception)
            {
                _logger.LogError(
                exception,
                "Error has happened with {RequestPath}, the message is {ErrorMessage}",
                context.Request.Path.Value, exception.Message);

                ProblemDetails problemDetails;

                switch (exception)
                {
                    case ValidationException validationException:
                        problemDetails = _problemDetailsFactory.CreateFrom(context, validationException);
                        _logger.LogInformation(validationException, "Somebody sent invalid request, oops");
                        break;
                    case DomainException domainException:
                        problemDetails = _problemDetailsFactory.CreateFrom(context, domainException);
                        _logger.LogError(domainException, "Domain exception occurred");
                        break;
                    default:
                        problemDetails = _problemDetailsFactory.CreateProblemDetails(
                            context, StatusCodes.Status500InternalServerError, "Unhandled error! Please contact us.");
                        _logger.LogError(exception, "Unhandled exception occurred");
                        break;
                }

                context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(problemDetails, problemDetails.GetType());

            }
        }
    }
}
