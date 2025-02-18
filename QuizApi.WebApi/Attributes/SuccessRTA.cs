using Microsoft.AspNetCore.Mvc;

namespace QuizApi.WebApi.Attributes;

public class SuccessRTA<T> : ProducesResponseTypeAttribute
{
    public SuccessRTA() : base(typeof(T), 200) { }
}