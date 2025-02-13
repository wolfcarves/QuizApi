namespace QuizApi.Application.Interfaces.Services;

public interface IJwtTokenService
{
    string GenerateAccessToken(string userId, string username, string role);
}