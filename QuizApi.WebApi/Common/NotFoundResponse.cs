using System.ComponentModel;

namespace QuizApi.WebApi.Common;

public class NotFoundResponse
{
    [DefaultValue(404)]
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
}