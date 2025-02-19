namespace QuizApi.Core.Entities;

public class Choice : BaseEntity
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; } = null!;
    public bool Is_Correct { get; set; }

    public Question Question { get; set; } = null!;

}