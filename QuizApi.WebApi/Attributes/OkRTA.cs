using Microsoft.AspNetCore.Mvc;

namespace QuizApi.WebApi.Attributes;

public class OkRTA : ProducesResponseTypeAttribute
{
    public OkRTA() : base(typeof(SuccessResponse<object>), 200) { }
}