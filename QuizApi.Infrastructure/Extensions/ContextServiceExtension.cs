using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApi.Infrastructure.Persistence;

namespace QuizApi.Infrastructure.Extensions;

public static class ContextServiceExtension
{
    public static IServiceCollection AddCustomAppDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}