using Microsoft.AspNetCore.Mvc;
using QuizApi.Core.Exceptions;


[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    public AuthController() { }

    [HttpGet("login", Name = "LoginUser", Order = 4)]
    public IActionResult Login()
    {
        throw new NotFoundException("");
    }
}