using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using QuizApi.Application.Validations.User;

namespace QuizApi.Application.Extensions;

public static class FluentValidationExtensions
{
    public static IServiceCollection AddCustomValidatorsFromAssembly(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<UserSignupValidation>(ServiceLifetime.Transient);
        return services;
    }

    public static void ValidateAndThrowArgumentException<T>(this IValidator<T> validator, T instance)
    {
        var res = validator.Validate(instance);

        if (!res.IsValid)
        {
            var ex = new ValidationException(res.Errors);
            throw new ArgumentException(ex.Message, ex);
        }
    }
}