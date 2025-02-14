namespace QuizApi.WebApi.Common;

public class BadRequestResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}