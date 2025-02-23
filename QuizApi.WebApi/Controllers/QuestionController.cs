using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.Interfaces.Services;
using QuizApi.WebApi.Application.DTO.Question;
using QuizApi.WebApi.Attributes;

namespace QuizApi.WebApi.Controllers;

[RequireAuth]
[ApiController]
[Route("api/v1/[controller]")]
[EnableCors("AllowAll")]
[ServerInternalRTA]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService) => _questionService = questionService;

    [HttpPost("{quizId}", Name = "PostApiV1CreateQuestion")]
    [SuccessRTA<IEnumerable<QuestionCreateDTO>>]
    [BadRequestRTA]
    public async Task<ActionResult<IEnumerable<QuestionCreateDTO>>> CreateQuestion(int quizId, [FromBody] IEnumerable<QuestionCreateDTO> requestBody)
    {
        var createdQuestions = await _questionService.CreateQuestionAsync(quizId, requestBody);

        return Ok(createdQuestions);
    }

    [HttpGet("{quizId}", Name = "GetApiV1QuestionsByQuizId")]
    [SuccessRTA<IEnumerable<QuestionDTO>>]
    [UnauthorizedRTA]
    public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestionsByQuizId(int quizId)
    {
        var questions = await _questionService.GetAllQuestionsByQuizIdAsync(quizId);

        return Ok(questions);
    }
}