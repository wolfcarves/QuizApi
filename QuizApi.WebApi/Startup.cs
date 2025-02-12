namespace QuizApi.WebApi;

using System.ComponentModel.Design;
using Microsoft.OpenApi.Models;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddProblemDetails();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddOpenApi();
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "QuizApi",
                    Version = "v1",
                    Description = "QuizApi ni Rodel Malupet, powered by ChatGPT 4 mini",
                });
            }
        );
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