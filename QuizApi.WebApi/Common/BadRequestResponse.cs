using System.ComponentModel;

namespace QuizApi.WebApi.Common;

public class BadRequestResponse
{
    [DefaultValue(400)]
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
    public Dictionary<string, string[]> Errors { get; set; } = new();
}