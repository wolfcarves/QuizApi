namespace QuizApi.WebApi.Application.DTO.Quiz;

public class QuizCreateDTO
{
    public required string Title { get; set; }
    public string Description { get; set; } = String.Empty;
}