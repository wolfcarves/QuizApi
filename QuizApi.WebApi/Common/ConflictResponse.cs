namespace QuizApi.WebApi.Common;

public class ConflictResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}