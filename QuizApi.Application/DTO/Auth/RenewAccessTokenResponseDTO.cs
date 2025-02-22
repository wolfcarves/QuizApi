using System.ComponentModel.DataAnnotations;

namespace QuizApi.WebApi.Application.DTO.Auth;

public class RenewAccessTokenResponseDTO
{
    [Required]
    public string AccessToken { get; set; }
}