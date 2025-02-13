namespace QuizApi.WebApi;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using QuizApi.Infrastructure.Configuration;
using DotNetEnv;
using QuizApi.Infrastructure.Extensions;
using QuizApi.Application.Extensions;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Env.Load();
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddProblemDetails();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddCustomSwaggerGen();
        services.AddOpenApi();
        services.AddApplicationService();
        services.AddJwtService();
        services.AddRepositoriesScope();
        services.AddCustomAppDbContext(Configuration);

        var tokenParameters = JwtConfiguration.GetTokenValidationParameters();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = tokenParameters);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseExceptionHandler();
        }
        else
        {
            app.UseExceptionHandler(opt => { });
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(
            endpoints => endpoints.MapControllers()
        );
    }
}