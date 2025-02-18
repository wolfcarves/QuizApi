using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace QuizApi.Infrastructure.Extensions;

public static class SwaggerServiceExtension
{
    public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
    {
        return services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo
                            {
                                Title = "QuizApi",
                                Version = "v1",
                                Description = "QuizApi ni Rodel Malupet, powered by ChatGPT 4 mini",
                            });

                            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                            {
                                Description = "Enter 'Bearer {your token}' (without quotes). Example: Bearer abc123",
                                Name = "Authorization",
                                In = ParameterLocation.Header,
                                Type = SecuritySchemeType.Http,
                                Scheme = "Bearer"
                            });

                            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                            {
                                {
                                    new OpenApiSecurityScheme
                                    {
                                        Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer"
                                        }
                                    },
                                    new List<string>()
                                }
                            });
                        }
               );
    }
}