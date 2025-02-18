using FluentValidation;
using QuizApi.WebApi.Application.DTO.Quiz;

namespace QuizApi.Application.Validators.User;

public class QuizCreateValidator : AbstractValidator<QuizCreateDTO>
{
    public QuizCreateValidator()
    {
        RuleFor(quiz => quiz.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(3).WithMessage("Please add appropriate title");
    }
}