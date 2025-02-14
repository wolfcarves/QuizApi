using Microsoft.AspNetCore.Mvc;
using QuizApi.WebApi.Common;

namespace QuizApi.WebApi.Attributes;

public class NotFoundRTA : ProducesResponseTypeAttribute
{
    public NotFoundRTA() : base(typeof(NotFoundResponse), 404) { }
}