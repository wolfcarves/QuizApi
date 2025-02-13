using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.Services;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    public UserController(UserService userService) => _userService = userService;

    [HttpGet("{username}")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        return Ok(await _userService.GetUserAsync(username));
    }
}