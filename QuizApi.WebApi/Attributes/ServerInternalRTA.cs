using Microsoft.AspNetCore.Mvc;
using QuizApi.WebApi.Common;

namespace QuizApi.WebApi.Attributes;

public class ServerInternalRTA : ProducesResponseTypeAttribute
{
    public ServerInternalRTA() : base(typeof(ServerInternalResponse), 500) { }
}