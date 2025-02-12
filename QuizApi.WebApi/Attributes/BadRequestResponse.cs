using Microsoft.AspNetCore.Mvc;
using QuizApi.WebApi.Models;

namespace QuizApi.WebApi.Attributes;

public class BadRequestResponse : ProducesResponseTypeAttribute
{
    public BadRequestResponse() : base(typeof(ErrorResponse), 400) { }
}