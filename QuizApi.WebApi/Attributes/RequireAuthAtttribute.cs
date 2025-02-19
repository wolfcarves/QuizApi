using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using QuizApi.Core.Entities;
using QuizApi.Core.Exceptions;
using QuizApi.Infrastructure.Authentication;

namespace QuizApi.WebApi.Attributes;

public class RequireAuthAttribute : Attribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var httpContext = context.HttpContext;
        var authHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();

        if (string.IsNullOrWhiteSpace(authHeader))
        {
            throw new BadRequestException("Missing Authorization Header.");
        }

        if (!authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            throw new BadRequestException("Invalid token format. Expected 'Bearer {token}'.");
        }

        var token = authHeader["Bearer ".Length..].Trim();

        if (string.IsNullOrEmpty(token) || IsValidToken(token) == null)
        {
            throw new BadRequestException("Unauthorized");
        }

        var userId = GetUserIdFromToken(token);

        httpContext.Items["UserId"] = userId;

        await Task.CompletedTask;
    }

    private ClaimsPrincipal? IsValidToken(string token)
    {
        try
        {
            var jwt = new JwtTokenService();
            return jwt.ValidateAccessToken(token);
        }
        catch
        {
            return null;
        }
    }

    private string? GetUserIdFromToken(string token)
    {
        try
        {
            var jwt = new JwtTokenService();
            var claimsPrincipal = jwt.ValidateAccessToken(token);

            var userIdClaim = claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userIdClaim;
        }
        catch
        {
            return null;
        }
    }
}
