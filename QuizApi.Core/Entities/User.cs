namespace QuizApi.Core.Entities;

public class User : BaseEntity
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }

    public ICollection<Quiz> Quizzes { get; set; } = null!;
}