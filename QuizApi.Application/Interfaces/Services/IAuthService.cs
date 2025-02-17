using QuizApi.Application.DTO.User;

namespace QuizApi.Application.Interfaces.Services;

public interface IAuthService
{
    Task<(string accessToken, string refreshToken)> LoginUserAsync(UserLoginDTO requestBody);
    Task<UserDTO> SignUpAsync(UserSignUpDTO requestBody);
    Task<UserDTO> GetUserSessionAsync(string? accessToken);
}