namespace QuizApi.WebApi;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using QuizApi.Infrastructure.Configuration;
using DotNetEnv;
using QuizApi.Infrastructure.Extensions;
using QuizApi.Application.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;

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
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
                });
        services.AddFluentValidationAutoValidation();
        services.AddProblemDetails();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddCustomSwaggerGen();
        services.AddOpenApi();
        services.AddApplicationService();
        services.AddJwtService();
        services.AddRepositoriesScope();
        services.AddCustomAppDbContext(Configuration);
        services.AddAutoMapperProfiles();

        var tokenParameters = JwtConfiguration.GetTokenValidationParameters();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Authority = "http://localhost:5000";
                        options.Audience = "http://localhost:5000";
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = tokenParameters;
                    });

        services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowAll",
                policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .AllowAnyHeader();
                });
        });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseExceptionHandler();

        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(
            endpoints => endpoints.MapControllers()
        );
    }
}