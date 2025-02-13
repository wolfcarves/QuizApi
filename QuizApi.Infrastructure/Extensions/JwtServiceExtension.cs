using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApi.Infrastructure.Authentication;

namespace QuizApi.Infrastructure.Extensions;

public static class JwtServiceExtension
{
    public static IServiceCollection AddJwtService(this IServiceCollection services)
    {
        return services.AddScoped<JwtTokenService>();
    }
}