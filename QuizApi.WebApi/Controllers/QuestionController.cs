using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.Interfaces.Services;
using QuizApi.WebApi.Application.DTO.Question;
using QuizApi.WebApi.Attributes;

namespace QuizApi.WebApi.Controllers;

[RequireAuth]
[ApiController]
[Route("api/v1/[controller]")]
[ServerInternalRTA]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService) => _questionService = questionService;

    // [HttpPost("{quizId}")]
    // [SuccessRTA<IEnumerable<QuestionCreateDTO>>]
    // [BadRequestRTA]
    // public async Task<IActionResult> CreateQuestion(int quizId, [FromBody] IEnumerable<QuestionCreateDTO> requestBody)
    // {
    //     var createdQuestions = await _questionService.CreateQuestionAsync(quizId, requestBody);
    //     return Ok(createdQuestions);
    // }

    [HttpPost("{quizId}")]
    [SuccessRTA<IEnumerable<QuestionCreateDTO>>]
    [BadRequestRTA]
    public async Task<ActionResult<IEnumerable<QuestionCreateDTO>>> CreateQuestion(int quizId, [FromBody] IEnumerable<QuestionCreateDTO> requestBody)
    {
        var createdQuestions = await _questionService.CreateQuestionAsync(quizId, requestBody);

        return Ok(createdQuestions);
    }

    [HttpGet("{quizId}")]
    [UnauthorizedRTA]
    public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestionsByQuizId(int quizId)
    {
        var questions = await _questionService.GetAllQuestionsByQuizIdAsync(quizId);

        return Ok(questions);
    }
}