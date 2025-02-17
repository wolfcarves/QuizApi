using QuizApi.Core.Entities;

namespace QuizApi.Application.Interfaces.Services;

public interface IUserService
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByUsernameAsync(string username);
}