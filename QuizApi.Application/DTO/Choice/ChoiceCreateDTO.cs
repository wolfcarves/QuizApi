namespace QuizApi.WebApi.Application.DTO.Choice;

public class ChoiceCreateDTO
{
    public int QuestionId { get; set; }
    public string Text { get; set; } = null!;
    public bool Is_Correct { get; set; }
}