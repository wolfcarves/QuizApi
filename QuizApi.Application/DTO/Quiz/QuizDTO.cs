using QuizApi.Application.DTO.User;
using QuizApi.Core.Entities;

namespace QuizApi.WebApi.Application.DTO.Quiz;

public class QuizDTO : BaseEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = null!;
    public bool Is_Published { get; set; } = false;
    public UserDTO User { get; set; } = null!;
}