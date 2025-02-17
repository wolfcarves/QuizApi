using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.DTO.User;
using QuizApi.Application.Interfaces.Services;
using QuizApi.WebApi.Attributes;

[ApiController]
[Route("api/v1/[controller]")]
[SuccessRTA]
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

        var accessToken = _jwtService.GenerateAccessToken($"{user.Id}", user.Username, "user");
        var refreshToken = _jwtService.GenerateRefreshToken();

        return Ok(new
        {
            success = StatusCodes.Status200OK,
            data = new
            {
                accessToken,
                refreshToken
            },
            message = "Login successfully."
        });
    }

    [HttpPost("signup", Name = "SignupUser")]
    [BadRequestRTA]
    [ConflictRTA]
    public async Task<ActionResult<UserDTO>> Signup([FromBody] UserSignUpDTO requestBody)
    {
        var user = await _authService.SignUpAsync(requestBody);

        return CreatedAtRoute("GetUserById", new { userId = user.Id }, new
        {
            status = StatusCodes.Status201Created,
            data = user,
            message = "User succesfully created."
        });
    }

    // [HttpGet]
    // public ActionResult<string> ValidateTokenKey(string token)
    // {
    //     var result = JsonSerializer.Serialize(_jwtService.ValidateToken(token), new JsonSerializerOptions
    //     {
    //         WriteIndented = true,
    //         ReferenceHandler = ReferenceHandler.IgnoreCycles,
    //     });
    //     return Ok(new SuccessResponse<object>("awd"));
    // }
}