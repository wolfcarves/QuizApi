using AutoMapper;
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Application.Interfaces.Services;
using QuizApi.Core.Entities;
using QuizApi.Core.Exceptions;
using QuizApi.WebApi.Application.DTO.Question;

namespace QuizApi.Application.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<QuestionDTO>> CreateQuestionAsync(int quizId, IEnumerable<QuestionCreateDTO> requestBody)
    {
        if (requestBody == null || !requestBody.Any())
            throw new BadRequestException("Request body cannot be null");

        var questions = _mapper.Map<List<Question>>(requestBody);

        foreach (var question in questions)
            question.QuizId = quizId;

        var createdQuestion = await _questionRepository.Create(questions);

        return _mapper.Map<IEnumerable<QuestionDTO>>(createdQuestion);
    }

    public async Task<IEnumerable<QuestionDTO>> GetAllQuestionsByQuizIdAsync(int quizId)
    {
        var questions = await _questionRepository.FindAll(quizId);

        return _mapper.Map<IEnumerable<QuestionDTO>>(questions);
    }
}
