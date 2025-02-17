using System.ComponentModel;

namespace QuizApi.WebApi.Common;

public class ForbiddenResponse
{
    [DefaultValue(403)]
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
}