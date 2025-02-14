namespace QuizApi.WebApi.Common;

public class ForbiddenResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}