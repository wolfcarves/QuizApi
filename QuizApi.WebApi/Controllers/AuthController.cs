using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.DTO.User;
using QuizApi.Application.Interfaces.Services;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IJwtTokenService _jwtService;

    public AuthController(IAuthService authService, IJwtTokenService jwtService)
    {
        _authService = authService;
        _jwtService = jwtService;
    }

    [HttpPost("login", Name = "LoginUser")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO requestBody)
    {
        string username = requestBody.Username;
        string password = requestBody.Password;

        // var user = await _authService.LoginUserAsync(username, password);

        return Ok("user");

        // return Ok(jwt.GenerateAccessToken($"{user.Id}", user.Username, "user"));
    }

    [HttpGet]
    public ActionResult<string> ValidateTokenKey(string token)
    {
        // var result = JsonSerializer.Serialize(_jwtService.ValidateToken(token), new JsonSerializerOptions
        // {
        //     WriteIndented = true,
        //     ReferenceHandler = ReferenceHandler.IgnoreCycles,
        // });
        return Ok(new SuccessResponse<object>("awd"));
    }
}