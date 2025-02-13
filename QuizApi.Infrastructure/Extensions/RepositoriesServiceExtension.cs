using Microsoft.Extensions.DependencyInjection;
using QuizApi.Application.Interfaces.Repositories;
using QuizApi.Infrastructure.Repositories;

namespace QuizApi.Infrastructure.Extensions;

public static class RepositoriesServiceExtension
{
    public static IServiceCollection AddRepositoriesScope(this IServiceCollection services)
    {
        return services.AddScoped<IUserRepository, UserRepository>();
    }
}