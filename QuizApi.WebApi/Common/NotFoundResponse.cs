namespace QuizApi.WebApi.Common;

public class NotFoundResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}