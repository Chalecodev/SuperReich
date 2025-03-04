﻿using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperReich.Application.Features.Rooms.Queries.GetRooms;
using SuperReich.Application.Features.Rooms.Queries.GetRoomsFiltered;
using SuperReich.Domain.Entities.Rooms;

namespace SuperReich.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet("GetRooms")]
        [ProducesResponseType(typeof(IReadOnlyList<Room>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<Room>>> GetRooms()
        {
            var query = new GetRoomsQuery();
            var rooms = await _sender.Send(query);

            return Ok(rooms);
        }

        [HttpGet("GetFilteredRooms")]
        [ProducesResponseType(typeof(IReadOnlyList<Room>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<Room>>> GetFilteredRooms(string? searchTerm)
        {
            var query = new GetRoomsFilteredQuery(searchTerm);  
            var result = await _sender.Send(query);

            return Ok(result);
        }
    }
}
