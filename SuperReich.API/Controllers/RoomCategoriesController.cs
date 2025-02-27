using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperReich.Application.Features.RoomCategories.Queries.GetRoomCategories;
using SuperReich.Domain.Entities.RoomCategories;

namespace SuperReich.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomCategoriesController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet("GetRoomCaregories")]
        [ProducesResponseType(typeof(IReadOnlyList<RoomCategory>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<RoomCategory>>> GetRoomCaregories()
        {
            var query = new GetRoomCategoriesQuery();
            var roomCategories = await _sender.Send(query);

            return Ok(roomCategories);
        }
    }
}
