using System.ComponentModel.DataAnnotations;

namespace QuizApi.Application.DTO.User;

public class UserSignUpDTO
{
    [Required]
    public required string Firstname { get; set; }
    [Required]
    public required string Lastname { get; set; }
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    public required string ConfirmPassword { get; set; }
}