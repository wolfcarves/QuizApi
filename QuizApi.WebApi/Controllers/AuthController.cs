using Microsoft.AspNetCore.Mvc;
using QuizApi.Core.Exceptions;
using QuizApi.WebApi.Attributes;


[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    public AuthController() { }

    [HttpPost("login", Name = "LoginUser", Order = 4)]
    [NotFoundResponse]
    public IActionResult Login()
    {
        throw new NotFoundException("");
    }
}