using System.ComponentModel;

namespace QuizApi.WebApi.Common;

public class ConflictResponse
{
    [DefaultValue(409)]
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
}