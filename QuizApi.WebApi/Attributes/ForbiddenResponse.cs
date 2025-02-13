using Microsoft.AspNetCore.Mvc;
using QuizApi.WebApi.Common;

namespace QuizApi.WebApi.Attributes;

public class ForbiddenResponse : ProducesResponseTypeAttribute
{
    public ForbiddenResponse() : base(typeof(ErrorResponse), 403) { }
}