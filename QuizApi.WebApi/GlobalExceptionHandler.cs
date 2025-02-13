using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using QuizApi.Core.Exceptions;

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
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ConflictException => StatusCodes.Status409Conflict,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new
            {
                statusCode = httpContext.Response.StatusCode,
                message = contextFeature.Error.Message
            };

            var jsonResponse = JsonSerializer.Serialize(response);
            await httpContext.Response.WriteAsync(jsonResponse);
        }

        return true;
    }
}