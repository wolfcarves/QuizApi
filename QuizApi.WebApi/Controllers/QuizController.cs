using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.Interfaces.Services;
using QuizApi.WebApi.Application.DTO.Quiz;
using QuizApi.WebApi.Attributes;

namespace QuizApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[ServerInternalRTA]
public class QuizController : BaseController
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService) { _quizService = quizService; }

    [HttpGet]
    [SuccessRTA<GetQuizzesResponseDTO>]
    [UnauthorizedRTA]
    [ValidateToken]
    public async Task<IActionResult> GetQuizzes()
    {
        var quizzes = await _quizService.GetQuizzesAsync();
        return Ok(quizzes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuiz([FromBody] QuizCreateDTO body)
    {
        var response = await _quizService.CreateQuizAsync(body);
        return Ok(response, "Let's go");
    }
}