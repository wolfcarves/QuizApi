using Microsoft.AspNetCore.Mvc;

namespace QuizApi.WebApi.Attributes;

public class SuccessRTA : ProducesResponseTypeAttribute
{
    public SuccessRTA() : base(typeof(SuccessResponse<object>), 200) { }
}