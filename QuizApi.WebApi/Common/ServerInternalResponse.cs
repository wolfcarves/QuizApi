using System.ComponentModel;

namespace QuizApi.WebApi.Common;

public class ServerInternalResponse
{
    [DefaultValue(500)]
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
}