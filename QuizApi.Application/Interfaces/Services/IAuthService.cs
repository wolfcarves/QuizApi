using QuizApi.Core.Entities;

namespace QuizApi.Application.Interfaces.Services;

public interface IAuthService
{
    Task<User> LoginUserAsync(string username, string password);
}