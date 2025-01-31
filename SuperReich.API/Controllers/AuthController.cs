using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperReich.Application.Features.Auth.Commands;

namespace SuperReich.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;
        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginCommand>> Login(LoginCommand request)
        {
            var response = await _sender.Send(request);

            return Ok(response);
        }
    }
}
