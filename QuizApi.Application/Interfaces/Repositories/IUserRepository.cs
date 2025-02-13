using QuizApi.Core.Entities;

namespace QuizApi.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> FindOneById(int userId);
    Task<User?> FindOneByUsername(string username);
}