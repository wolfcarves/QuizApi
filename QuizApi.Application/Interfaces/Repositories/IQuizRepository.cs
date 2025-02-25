using QuizApi.Core.Entities;

namespace QuizApi.Application.Interfaces.Repositories;

public interface IQuizRepository
{
    Task<IEnumerable<Quiz>> FindAll();
    Task<Quiz?> FindOneById(int quizId);
    Task<Quiz> Create(Quiz quiz);
}