using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperReich.Application.Features.Customers.Commands.CreateCustomer;
using SuperReich.Application.Features.Customers.Queries.GetCustomers;
using SuperReich.Domain.Entities.Customers;
using SuperReich.Domain.Entities.Users;

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

        [HttpPost("CreateCustomer")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            return await _sender.Send(command);
        }
    }
}
