using QuizApi.Application.DTO.User;
using QuizApi.Core.Entities;

namespace QuizApi.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserDTO?> GetUserByIdAsync(int id);
    Task<UserDTO?> GetUserByUsernameAsync(string username);
}