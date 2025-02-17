using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.Services;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    public UserController(UserService userService) => _userService = userService;

    [HttpGet("{userId}", Name = "GetUserById")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);
        return Ok(user);
    }

    [HttpGet("username/{username}", Name = "GetUserByUsername")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        var user = await _userService.GetUserByUsernameAsync(username);
        return Ok(user);
    }
}