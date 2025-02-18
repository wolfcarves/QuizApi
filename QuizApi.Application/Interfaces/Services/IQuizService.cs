using QuizApi.Core.Entities;
using QuizApi.WebApi.Application.DTO.Quiz;


namespace QuizApi.Application.Interfaces.Services;

public interface IQuizService
{
    Task<IEnumerable<Quiz>> GetQuizzesAsync();
    Task<Quiz> CreateQuizAsync(QuizCreateDTO quizDto);
}