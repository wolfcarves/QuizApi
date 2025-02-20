namespace QuizApi.Core.Entities;

public class Question : BaseEntity
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string Text { get; set; } = null!;
    public int AnswerId { get; set; }

    public Quiz Quiz { get; set; } = null!;
    public ICollection<Choice> Choices { get; set; } = null!;
}