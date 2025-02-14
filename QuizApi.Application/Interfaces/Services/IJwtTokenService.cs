namespace QuizApi.Application.Interfaces.Services;

public interface IJwtTokenService
{
    string GenerateAccessToken(string userId, string username, string role);
    string GenerateRefreshToken();
    bool ValidateToken(string token);
}