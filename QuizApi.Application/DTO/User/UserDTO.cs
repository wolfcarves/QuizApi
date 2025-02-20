
using System.ComponentModel.DataAnnotations;

namespace QuizApi.Application.DTO.User;

public class UserDTO
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
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
}