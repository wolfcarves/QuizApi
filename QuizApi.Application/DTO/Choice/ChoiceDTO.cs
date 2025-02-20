using QuizApi.Core.Entities;

namespace QuizApi.WebApi.Application.DTO.Choice;

public class ChoiceDTO : BaseEntity
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; } = null!;
    public bool Is_Correct { get; set; }

}
