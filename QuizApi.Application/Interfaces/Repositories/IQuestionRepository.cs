using QuizApi.Core.Entities;

namespace QuizApi.Application.Interfaces.Repositories;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> Create(IEnumerable<Question> question);
    Task<IEnumerable<Question>> FindAll(int quizId);
}