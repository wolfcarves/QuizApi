using Microsoft.AspNetCore.Mvc;

namespace QuizApi.WebApi.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class BaseController : ControllerBase
{
    protected OkObjectResult Ok<T>(T data, string? message = "Operation successful.")
    {
        return base.Ok(new SuccessResponse<T>(data, message));
    }

    protected OkObjectResult Ok(string message)
    {
        return base.Ok(new SuccessResponse<object>(null!, message));
    }
}