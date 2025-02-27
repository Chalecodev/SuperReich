using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperReich.Application.Features.Bookings.Commands.CreateBooking;
using SuperReich.Application.Features.Bookings.Queries.GetBookings;
using SuperReich.Domain.Entities.Bookings;

namespace SuperReich.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet("GetBookings")]
        [ProducesResponseType(typeof(IReadOnlyList<Booking>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<Booking>>> GetBookings()
        {
            var query = new GetBookingsQuery();
            var bookings = await _sender.Send(query);

            return Ok(bookings);
        }

        [HttpPost("CreateBooking")]
        [ProducesResponseType(typeof(Booking), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateBooking([FromBody] CreateBookingCommand command)
        {
            return await _sender.Send(command);
        }
    }
}
