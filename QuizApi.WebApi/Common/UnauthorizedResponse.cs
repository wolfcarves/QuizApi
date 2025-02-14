namespace QuizApi.WebApi.Common;

public class UnauthorizedResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}