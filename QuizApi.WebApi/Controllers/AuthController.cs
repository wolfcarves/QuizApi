using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.DTO.User;
using QuizApi.Application.Interfaces.Services;
using QuizApi.WebApi.Attributes;

[ApiController]
[Route("api/v1/[controller]")]
[OkRTA]
[ServerInternalRTA]
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
    [UnauthorizedRTA]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO requestBody)
    {
        var user = await _authService.LoginUserAsync(requestBody);
        // var accessToken = _jwtService.GenerateAccessToken($"{user.Id}", user.Username, "user");

        var accessToken = _jwtService.GenerateAccessToken("1", "cazcade", "user");
        var refreshToken = _jwtService.GenerateRefreshToken();

        return Ok(new SuccessResponse<string>("My Message is here!"));
    }

    [HttpPost("signup", Name = "SignupUser")]
    [BadRequestRTA]
    [ConflictRTA]
    public async Task<ActionResult<UserDTO>> Signup([FromBody] UserSignUpDTO requestBody)
    {
        var user = await _authService.SignUpAsync(requestBody);
        return Ok(user);
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