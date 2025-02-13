using Microsoft.Extensions.DependencyInjection;
using QuizApi.Application.Interfaces.Services;
using QuizApi.Application.Services;

namespace QuizApi.Application.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}