using FluentValidation;
using QuizApi.Application.DTO.User;

namespace QuizApi.Application.Validators.User;

public class UserSignupValidator : AbstractValidator<UserSignUpDTO>
{
    public UserSignupValidator()
    {
        RuleFor(user => user.Firstname)
            .NotEmpty().WithMessage("First name is required.")
            .MinimumLength(2).WithMessage("First name must be at least 2 characters.");

        RuleFor(user => user.Lastname)
            .NotEmpty().WithMessage("Last name is required.")
            .MinimumLength(2).WithMessage("Last name must be at least 2 characters.");

        RuleFor(user => user.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
            .Matches(@"^(?!\d+$).*$").WithMessage("Username cannot contain only numbers.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches(@"^(?!\d+$).*$").WithMessage("Password cannot contain only numbers.");

        RuleFor(user => user.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm password is required.")
            .Equal(user => user.Password).WithMessage("Passwords do not match.");
    }
}