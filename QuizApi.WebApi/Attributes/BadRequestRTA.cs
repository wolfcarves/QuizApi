using Microsoft.AspNetCore.Mvc;
using QuizApi.WebApi.Common;

namespace QuizApi.WebApi.Attributes;

public class BadRequestRTA : ProducesResponseTypeAttribute
{
    public BadRequestRTA() : base(typeof(BadRequestResponse), 400) { }
}