using Microsoft.AspNetCore.Mvc;
using QuizApi.WebApi.Common;

namespace QuizApi.WebApi.Attributes;

public class UnauthorizedRTA : ProducesResponseTypeAttribute
{
    public UnauthorizedRTA() : base(typeof(UnauthorizedResponse), 401) { }
}