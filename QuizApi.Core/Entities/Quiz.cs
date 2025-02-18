

namespace QuizApi.Core.Entities;

public class Quiz : BaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = String.Empty;
    public bool Is_Published { get; set; }

    public User User { get; set; } = null!;
}