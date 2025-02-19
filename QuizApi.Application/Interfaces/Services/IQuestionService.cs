using QuizApi.Core.Entities;
using QuizApi.WebApi.Application.DTO.Question;

namespace QuizApi.Application.Interfaces.Services;

public interface IQuestionService
{
    Task<IEnumerable<QuestionDTO>> CreateQuestionAsync(int quizId, IEnumerable<QuestionCreateDTO> requestBody);
    Task<IEnumerable<QuestionDTO>> GetAllQuestionsByQuizIdAsync(int quizId);
}