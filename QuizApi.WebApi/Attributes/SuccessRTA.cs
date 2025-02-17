using Microsoft.AspNetCore.Mvc;

namespace QuizApi.WebApi.Attributes;

public class SuccessRTA<T> : ProducesResponseTypeAttribute
{
    public SuccessRTA() : base(typeof(SuccessResponse<T>), 200) { }
}