using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace QuizApi.Infrastructure.Extensions;

public static class SwaggerServiceExtension
{
    public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
    {
        return services.AddSwaggerGen(c =>
                        c.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Title = "QuizApi",
                            Version = "v1",
                            Description = "QuizApi ni Rodel Malupet, powered by ChatGPT 4 mini",
                        })
               );
    }
}