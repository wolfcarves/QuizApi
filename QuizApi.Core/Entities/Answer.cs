namespace QuizApi.Core.Entities;

public class Answer : BaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public int ChoiceId { get; set; }
}