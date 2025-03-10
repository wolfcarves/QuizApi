using AutoMapper;
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Application.Interfaces.Services;
using QuizApi.Core.Entities;
using QuizApi.Core.Exceptions;
using QuizApi.WebApi.Application.DTO.Question;

namespace QuizApi.Application.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuizRepository _quizRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IChoiceRepository _choiceRepository;
    private readonly IMapper _mapper;

    public QuestionService(IQuizRepository quizRepository, IQuestionRepository questionRepository, IChoiceRepository choiceRepository, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _questionRepository = questionRepository;
        _choiceRepository = choiceRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<QuestionDTO>> CreateQuestionAsync(int quizId, IEnumerable<QuestionCreateDTO> requestBody)
    {
        var existingQuiz = await _quizRepository.FindOneById(quizId) ?? throw new NotFoundException("Quiz not found");

        if (requestBody == null || !requestBody.Any())
            throw new BadRequestException("Request body cannot be null");

        var questions = _mapper.Map<List<Question>>(requestBody);

        foreach (var question in questions)
        {
            question.QuizId = quizId;

            if (question.Choices == null || !question.Choices.Any())
                throw new BadRequestException("Each question must have at least one choice.");

            if (!question.Choices.Any(c => c.Is_Correct))
                throw new BadRequestException("Each question must have at least one correct answer.");

            question.Choices = question.Choices.Select(choice => new Choice
            {
                Text = choice.Text,
                Is_Correct = choice.Is_Correct,
                QuestionId = question.Id
            }).ToList();
        }

        var createdQuestions = await _questionRepository.Create(questions);

        return _mapper.Map<IEnumerable<QuestionDTO>>(createdQuestions);
    }



    public async Task<IEnumerable<QuestionDTO>> GetAllQuestionsByQuizIdAsync(int quizId)
    {
        var questions = await _questionRepository.FindAll(quizId);

        return _mapper.Map<IEnumerable<QuestionDTO>>(questions);
    }
}
