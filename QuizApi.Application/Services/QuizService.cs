using AutoMapper;
using FluentValidation;
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Application.Interfaces.Services;
using QuizApi.Application.Validators.User;
using QuizApi.Core.Entities;
using QuizApi.WebApi.Application.DTO.Quiz;

namespace QuizApi.Application.Services;

public class QuizService : IQuizService
{
    private readonly IQuizRepository _quizRepository;
    private readonly IMapper _mapper;

    public QuizService(IQuizRepository quizRepository, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Quiz>> GetQuizzesAsync()
    {
        var quizzes = await _quizRepository.FindAll();
        return quizzes;
    }

    public async Task<Quiz> CreateQuizAsync(QuizCreateDTO quizDto)
    {
        QuizCreateValidator validator = new QuizCreateValidator();
        await validator.ValidateAndThrowAsync(quizDto);

        var quiz = _mapper.Map<Quiz>(quizDto);

        var createdQuiz = await _quizRepository.Create(quiz);

        return createdQuiz;
    }
}