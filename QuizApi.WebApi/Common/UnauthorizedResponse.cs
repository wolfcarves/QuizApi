using System.ComponentModel;

namespace QuizApi.WebApi.Common;

public class UnauthorizedResponse
{
    [DefaultValue(401)]
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
}