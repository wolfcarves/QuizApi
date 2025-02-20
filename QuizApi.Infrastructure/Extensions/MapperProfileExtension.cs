using Microsoft.Extensions.DependencyInjection;
using QuizApi.Application.Mappings;

namespace QuizApi.Infrastructure.Extensions;

public static class MapperProfileExtension
{
    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));
        services.AddAutoMapper(typeof(QuizProfile));
        services.AddAutoMapper(typeof(QuestionProfile));
        services.AddAutoMapper(typeof(ChoiceProfile));

        return services;
    }
}