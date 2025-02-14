using Microsoft.AspNetCore.Mvc;
using QuizApi.WebApi.Common;

namespace QuizApi.WebApi.Attributes;

public class ForbiddenRTA : ProducesResponseTypeAttribute
{
    public ForbiddenRTA() : base(typeof(ForbiddenResponse), 403) { }
}