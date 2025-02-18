using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.DTO.User;
using QuizApi.Application.Interfaces.Services;
using QuizApi.WebApi.Attributes;

[ApiController]
[Route("api/v1/[controller]")]
[UnauthorizedRTA]
[ServerInternalRTA]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId}", Name = "GetUserById")]
    [SuccessRTA<UserDTO>]
    [NotFoundRTA]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);
        return Ok(user);
    }

    [HttpGet("username/{username}", Name = "GetUserByUsername")]
    [SuccessRTA<UserDTO>]
    [NotFoundRTA]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        var user = await _userService.GetUserByUsernameAsync(username);
        return Ok(user);
    }
}