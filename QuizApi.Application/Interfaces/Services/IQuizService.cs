using QuizApi.Core.Entities;
using QuizApi.WebApi.Application.DTO.Quiz;


namespace QuizApi.Application.Interfaces.Services;

public interface IQuizService
{
    Task<IEnumerable<QuizDTO>> GetQuizzesAsync();
    Task<QuizDTO> CreateQuizAsync(int userId, QuizCreateDTO quizDto);
}