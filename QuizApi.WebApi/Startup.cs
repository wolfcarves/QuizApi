namespace QuizApi.WebApi;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using QuizApi.Infrastructure.Configuration;
using DotNetEnv;
using QuizApi.Infrastructure.Extensions;
using QuizApi.Application.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

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
        services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
                });
        services.AddFluentValidationAutoValidation();
        services.AddCustomValidatorsFromAssembly();
        services.AddProblemDetails();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddCustomSwaggerGen();
        services.AddOpenApi();
        services.AddApplicationService();
        services.AddJwtService();
        services.AddRepositoriesScope();
        services.AddCustomAppDbContext(Configuration);
        services.AddAutoMapper(typeof(UserProfile));

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