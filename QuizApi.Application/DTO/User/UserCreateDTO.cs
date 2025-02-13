namespace QuizApi.Application.DTO.User;

public class UserCreateDTO
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Username { get; set; }
}