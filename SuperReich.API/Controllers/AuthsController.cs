using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperReich.Application.Features.Auth.Commands;

namespace SuperReich.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost("Login")]
        public async Task<ActionResult<LoginCommand>> Login(LoginCommand request)
        {
            var response = await _sender.Send(request);

            return Ok(response);
        }
    }
}
