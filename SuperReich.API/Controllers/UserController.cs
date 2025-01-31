using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperReich.API.Errors;
using SuperReich.Application.Features.Users.Commands;
using SuperReich.Application.Features.Users.Queries;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;
        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("GetUsers")]
        [ProducesResponseType(typeof(IReadOnlyList<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IReadOnlyList<User>>> GetUsers()
        {
            var query = new GetUsersQuery();
            var users = await _sender.Send(query);
            return Ok(users);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateUserCommand command)
        {
            return await _sender.Send(command);
        }
    }
}
