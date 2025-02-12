namespace QuizApi.Core.Entities;

public class Admin : BaseEntity
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public List<Quiz> Quizzes { get; set; } = null!;
}