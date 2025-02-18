using QuizApi.Core.Entities;

namespace QuizApi.Application.DTO.User;

public class UserDTO : BaseEntity
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Username { get; set; }
}