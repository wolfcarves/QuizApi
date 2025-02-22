using System.Security;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.DTO.User;
using QuizApi.Application.Interfaces.Services;
using QuizApi.WebApi.Application.DTO.Auth;
using QuizApi.WebApi.Attributes;

namespace QuizApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[EnableCors("AllowAll")]
[ServerInternalRTA]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    [SuccessRTA<LoginResponseDTO>]
    [UnauthorizedRTA]
    public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO requestBody)
    {
        var (user, accessToken, refreshToken) = await _authService.LoginUserAsync(requestBody);

        Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Lax,
            Expires = DateTime.Now.AddMinutes(1)
        });

        return Ok(new
        {
            user.Id,
            user.Firstname,
            user.Lastname,
            user.Username,
            user.CreatedAt,
            user.UpdatedAt,
            AccessToken = accessToken,
        });
    }

    [HttpPost("signup")]
    [SuccessRTA<UserDTO>]
    [BadRequestRTA]
    [ConflictRTA]
    public async Task<IActionResult> SignupUser([FromBody] UserSignUpDTO requestBody)
    {
        var user = await _authService.SignupUserAsync(requestBody);

        return CreatedAtRoute("GetUserById", new { userId = user.Id }, user);
    }

    [HttpGet("session")]
    [SuccessRTA<UserDTO>]
    [UnauthorizedRTA]
    public async Task<ActionResult<UserDTO>> GetUserSession()
    {
        var accessToken = Request.Headers.Authorization;

        var user = await _authService.GetUserSessionAsync(accessToken);

        return Ok(user);
    }

    [HttpDelete("logout")]
    [SuccessRTA<UserDTO>]
    [UnauthorizedRTA]
    public async Task<ActionResult<UserDTO>> LogoutUser()
    {
        int userId = Convert.ToInt32(HttpContext.Items["UserId"]);

        Response.Cookies.Delete("refreshToken");
        var user = await _authService.DeleteUserSessionAsync(userId);

        return Ok(user);
    }

    [HttpGet("renew/accessToken")]
    public async Task<IActionResult> RenewAccessToken()
    {
        int userId = Convert.ToInt32(HttpContext.Items["UserId"]);

        var refreshToken = Request.Cookies["refreshToken"];

        var accessToken = await _authService.GetNewAccessTokenAsync(userId, refreshToken);

        return Ok(new
        {
            AccessToken = accessToken,
        });
    }
}