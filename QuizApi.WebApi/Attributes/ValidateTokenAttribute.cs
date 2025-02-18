using Microsoft.AspNetCore.Mvc.Filters;
using QuizApi.Core.Exceptions;
using QuizApi.Infrastructure.Authentication;

namespace QuizApi.WebApi.Attributes;

public class ValidateTokenAttribute : Attribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var httpContext = context.HttpContext;
        var authHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();

        if (string.IsNullOrWhiteSpace(authHeader))
        {
            throw new BadRequestException("Missing Authorization header.");
        }

        if (!authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            throw new BadRequestException("Invalid token format. Expected 'Bearer {token}'.");
        }

        var token = authHeader["Bearer ".Length..].Trim();

        if (string.IsNullOrEmpty(token) || !IsValidToken(token))
        {
            throw new BadRequestException("Invalid or expired token.");
        }

        await Task.CompletedTask;
    }

    private bool IsValidToken(string token)
    {
        try
        {
            var jwt = new JwtTokenService();
            return jwt.ValidateAccessToken(token);
        }
        catch
        {
            return false;
        }
    }
}
