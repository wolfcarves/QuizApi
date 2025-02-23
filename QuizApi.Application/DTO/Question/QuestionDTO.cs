using QuizApi.WebApi.Application.DTO.Choice;

namespace QuizApi.WebApi.Application.DTO.Question;

public class QuestionDTO
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string Text { get; set; } = null!;
    public int AnswerId { get; set; }

    public ICollection<ChoiceDTO> Choices { get; set; } = null!;
}