using Microsoft.AspNetCore.Mvc;
using QuizApi.WebApi.Models;

namespace QuizApi.WebApi.Attributes;

public class UnauthorizedResponse : ProducesResponseTypeAttribute
{
    public UnauthorizedResponse() : base(typeof(ErrorResponse), 401) { }
}