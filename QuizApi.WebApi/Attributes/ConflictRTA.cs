using Microsoft.AspNetCore.Mvc;
using QuizApi.WebApi.Common;

namespace QuizApi.WebApi.Attributes;

public class ConflictRTA : ProducesResponseTypeAttribute
{
    public ConflictRTA() : base(typeof(ConflictResponse), 409) { }
}