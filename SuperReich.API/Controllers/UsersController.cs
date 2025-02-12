﻿using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperReich.Application.Features.Users.Commands.CreateUser;
using SuperReich.Application.Features.Users.Queries.GetUsers;
using SuperReich.Domain.Entities.Users;
using SuperReich.Domain.Enums.RoleEnums;

namespace SuperReich.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        //[Authorize(Roles = "Administrador")]
        [HttpGet("GetUsers")]
        [ProducesResponseType(typeof(IReadOnlyList<User>), (int)HttpStatusCode.OK)]
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
