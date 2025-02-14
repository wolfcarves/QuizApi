namespace QuizApi.WebApi.Common;

public class ServerInternalResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}