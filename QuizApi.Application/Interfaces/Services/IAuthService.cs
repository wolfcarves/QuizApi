using QuizApi.Application.DTO.User;
using QuizApi.Core.Entities;

namespace QuizApi.Application.Interfaces.Services;

public interface IAuthService
{
    Task<(User user, string accessToken, string refreshToken)> LoginUserAsync(UserLoginDTO requestBody);
    Task<UserDTO> SignupUserAsync(UserSignUpDTO requestBody);
    Task<UserDTO> GetUserSessionAsync(string? accessToken);
    Task<UserDTO> DeleteUserSessionAsync(int userId);
    Task<string> GetNewAccessTokenAsync(int userId, string? refreshToken);
}