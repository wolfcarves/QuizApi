using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using QuizApi.Application.Validators.User;

namespace QuizApi.Application.Extensions;

public static class FluentValidationExtensions
{
    public static IServiceCollection AddCustomValidatorsFromAssembly(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<UserSignupValidator>(ServiceLifetime.Transient);
        return services;
    }
}