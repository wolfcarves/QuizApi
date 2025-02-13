using Microsoft.Extensions.DependencyInjection;
using QuizApi.Application.Interfaces.Services;
using QuizApi.Infrastructure.Authentication;

namespace QuizApi.Infrastructure.Extensions;

public static class JwtServiceExtension
{
    public static IServiceCollection AddJwtService(this IServiceCollection services)
    {
        return services.AddScoped<IJwtTokenService, JwtTokenService>();
    }
}