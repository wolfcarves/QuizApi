using Microsoft.Extensions.DependencyInjection;
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Infrastructure.Repositories;

namespace QuizApi.Infrastructure.Extensions;

public static class InfrastructureRepositoriesExtension
{
    public static IServiceCollection AddRepositoriesScope(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IQuizRepository, QuizRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();

        return services;
    }
}