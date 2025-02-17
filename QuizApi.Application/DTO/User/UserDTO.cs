namespace QuizApi.Application.DTO.User;

public class UserDTO
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Username { get; set; }
}