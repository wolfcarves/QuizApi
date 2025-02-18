using QuizApi.Core.Entities;

namespace QuizApi.WebApi.Application.DTO.Quiz;

public class GetQuizzesResponseDTO : BaseEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public int QuestionsCount { get; set; }
}