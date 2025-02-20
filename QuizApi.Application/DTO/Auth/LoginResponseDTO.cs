using System.ComponentModel.DataAnnotations;

namespace QuizApi.WebApi.Application.DTO.Auth;

public class LoginResponseDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string AccessToken { get; set; }
    [Required]
    public string CreatedAt { get; set; }
    [Required]
    public string UpdatedAt { get; set; }
}