using System.Security.Claims;

namespace QuizApi.Application.Interfaces.Services;

public interface IJwtTokenService
{
    string GenerateAccessToken(string userId, string username);
    string GenerateRefreshToken();
    ClaimsPrincipal ValidateAccessToken(string token);
    bool ValidateRefreshToken(string token);
}