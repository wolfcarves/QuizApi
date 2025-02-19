namespace QuizApi.WebApi.Application.DTO.Question;

public class QuestionDTO
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string Text { get; set; } = null!;
}