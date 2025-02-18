using Microsoft.AspNetCore.Diagnostics;
using QuizApi.Core.Exceptions;
using FluentValidation;
using System.Text.Json;

namespace QuizApi.WebApi;

public class GlobalExceptionHandler : IExceptionHandler
{
    public GlobalExceptionHandler() { }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";

        var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature is not null)
        {
            httpContext.Response.StatusCode = contextFeature.Error switch
            {
                ValidationException => StatusCodes.Status400BadRequest,
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ConflictException => StatusCodes.Status409Conflict,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            object response;

            if (contextFeature.Error is ValidationException validationException)
            {
                response = new
                {
                    status = httpContext.Response.StatusCode,
                    message = "Validation Failed",
                    errors = validationException.Errors
                                                .GroupBy(e => e.PropertyName)
                                                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray())
                };
            }
            else
            {
                response = new
                {
                    status = httpContext.Response.StatusCode,
                    message = contextFeature.Error.Message
                };
            }

            var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower, DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower });
            await httpContext.Response.WriteAsync(jsonResponse);
        }

        return true;
    }
}