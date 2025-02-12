using Microsoft.AspNetCore.Mvc;
using QuizApi.WebApi.Models;

namespace QuizApi.WebApi.Attributes;

public class NotFoundResponse : ProducesResponseTypeAttribute
{
    public NotFoundResponse() : base(typeof(ErrorResponse), 404) { }
}