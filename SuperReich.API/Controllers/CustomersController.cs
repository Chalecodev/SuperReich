using MediatR;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperReich.Application.Features.Rooms.Queries.GetRooms;
using SuperReich.Domain.Entities.Rooms;
using SuperReich.Domain.Entities.Customers;
using SuperReich.Application.Features.Customers.Queries.GetCustomers;

namespace SuperReich.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet("GetCustomers")]
        [ProducesResponseType(typeof(IReadOnlyList<Customer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<Customer>>> GetCustomers()
        {
            var query = new GetCustomersQuery();
            var customers = await _sender.Send(query);

            return Ok(customers);
        }
    }
}
