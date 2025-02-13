using QuizApi.Core.Entities;

namespace QuizApi.Application.Interfaces.Services;

public interface IUserService
{
    Task<User> GetUserAsync(string username);
}