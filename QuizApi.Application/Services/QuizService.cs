using AutoMapper;
using FluentValidation;
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Application.Interfaces.Services;
using QuizApi.Application.Validators.User;
using QuizApi.Core.Entities;
using QuizApi.Core.Exceptions;
using QuizApi.WebApi.Application.DTO.Quiz;

namespace QuizApi.Application.Services;

public class QuizService : IQuizService
{
    private readonly IQuizRepository _quizRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public QuizService(IQuizRepository quizRepository, IUserRepository userRepository, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<QuizDTO>> GetQuizzesAsync()
    {
        var quizzes = await _quizRepository.FindAll();
        return _mapper.Map<IEnumerable<QuizDTO>>(quizzes);
    }

    public async Task<QuizDTO> CreateQuizAsync(int userId, QuizCreateDTO quizDto)
    {
        // QuizCreateValidator validator = new QuizCreateValidator();
        // await validator.ValidateAndThrowAsync(quizDto);

        var user = await _userRepository.FindOneById(userId);
        if (user == null) throw new UnauthorizedException("Unauthorized");

        var quiz = _mapper.Map<Quiz>(quizDto);
        quiz.UserId = userId;

        var createdQuiz = await _quizRepository.Create(quiz);

        return _mapper.Map<QuizDTO>(createdQuiz);
    }
}