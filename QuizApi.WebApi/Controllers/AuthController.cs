using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.DTO.User;
using QuizApi.Application.Interfaces.Services;
using QuizApi.WebApi.Application.DTO.Auth;
using QuizApi.WebApi.Attributes;

namespace QuizApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[ServerInternalRTA]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login", Name = "LoginUser")]
    [SuccessRTA<LoginResponseDTO>]
    [UnauthorizedRTA]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO requestBody)
    {
        var (accessToken, refreshToken) = await _authService.LoginUserAsync(requestBody);

        Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Lax,
            Expires = DateTime.Now.AddDays(7)
        });

        return Ok(
                new LoginResponseDTO { AccessToken = accessToken, },
                "Login success!"
        );
    }

    [HttpPost("signup", Name = "SignupUser")]
    [SuccessRTA<UserDTO>]
    [BadRequestRTA]
    [ConflictRTA]
    public async Task<IActionResult> Signup([FromBody] UserSignUpDTO requestBody)
    {
        var user = await _authService.SignUpAsync(requestBody);

        return CreatedAtRoute("GetUserById", new { userId = user.Id }, user);
    }

    [HttpGet]
    [SuccessRTA<UserDTO>]
    [UnauthorizedRTA]
    public async Task<IActionResult> GetUserSession()
    {
        var accessToken = Request.Headers.Authorization;

        var user = await _authService.GetUserSessionAsync(accessToken);

        return Ok(new UserDTO
        {
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Username = user.Username,
        });
    }


}