using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.DTO.User;
using QuizApi.Application.Services;
using QuizApi.Core.Exceptions;
using QuizApi.Infrastructure.Authentication;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly JwtTokenService _jwtService;
    public AuthController(AuthService authService, JwtTokenService jwtService)
    {
        _authService = authService;
        _jwtService = jwtService;
    }

    [HttpPost("login", Name = "LoginUser")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO requestBody)
    {
        var jwt = new JwtTokenService();

        string username = requestBody.Username;
        string password = requestBody.Password;

        var user = await _authService.LoginUserAsync(username, password);

        return Ok(jwt.GenerateAccessToken($"{user.Id}", user.Username, "user"));
    }

    [HttpGet]
    public string ValidateTokenKey(string token)
    {
        var result = JsonSerializer.Serialize(_jwtService.ValidateToken(token), new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
        });

        return result;
    }
}