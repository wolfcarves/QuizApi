using QuizApi.Application.DTO.User;
using QuizApi.Core.Entities;

namespace QuizApi.Application.Interfaces.Services;

public interface IAuthService
{
    Task<User> LoginUserAsync(UserLoginDTO requestBody);
    Task<UserDTO> SignUpAsync(UserSignUpDTO requestBody);
}