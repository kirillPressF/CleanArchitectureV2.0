using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CleanArchitectureV2._0.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllUserResponse>>>
        //public async Task<IActionResult> Get([FromQuery] string email, CancellationToken cancellationToken)
        //{
        //    var user = await _mediator.Send(new GetUserByEmailQuery(email), cancellationToken);
        //    return Ok(user);
        //}
    }
}
