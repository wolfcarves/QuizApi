using Microsoft.AspNetCore.Mvc;
using QuizApi.WebApi.Common;

namespace QuizApi.WebApi.Attributes;

public class ConflictResponse : ProducesResponseTypeAttribute
{
    public ConflictResponse() : base(typeof(ErrorResponse), 409) { }
}