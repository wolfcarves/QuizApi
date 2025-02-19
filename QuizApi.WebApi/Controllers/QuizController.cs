using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.Interfaces.Services;
using QuizApi.WebApi.Application.DTO.Quiz;
using QuizApi.WebApi.Attributes;

namespace QuizApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[ServerInternalRTA]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService) => _quizService = quizService;

    [HttpGet]
    [SuccessRTA<IEnumerable<QuizDTO>>]
    [UnauthorizedRTA]
    [RequireAuth]
    public async Task<ActionResult<IEnumerable<QuizDTO>>> GetQuizzes()
    {
        var quizzes = await _quizService.GetQuizzesAsync();
        return Ok(quizzes);
    }

    [HttpPost]
    [SuccessRTA<QuizDTO>]
    [RequireAuth]
    public async Task<ActionResult<QuizDTO>> CreateQuiz([FromBody] QuizCreateDTO body)
    {
        var userId = Convert.ToInt32(HttpContext.Items["UserId"]);

        var createdQuiz = await _quizService.CreateQuizAsync(userId, body);

        return Ok(createdQuiz);
    }
}