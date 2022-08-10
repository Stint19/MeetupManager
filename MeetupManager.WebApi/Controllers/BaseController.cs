using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MeetupManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Parse("2EB57FD8-35E5-4471-BC0B-FD0D391C4487")
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
