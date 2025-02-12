namespace QuizApi.WebApi;

class Program
{
    public static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
                        .ConfigureWebHostDefaults(webBuilder =>
                            webBuilder.UseStartup<Startup>()
                        ).Build();

        await builder.RunAsync();
    }
}
