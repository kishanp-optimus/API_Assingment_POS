using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Application.DTO;
using POS.Application.Features.UsersFeature.Command;
using POS.Application.Features.UsersFeature.Query;
using System;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) {
            _mediator = mediator;
        }
        [HttpPost("/CreateUser/{user}")]
        public IActionResult CreateUser(UserDTO user)
        {
            var res = _mediator.Send(new CreateUserCommand(user));
            return Ok(res);
        }
        [HttpPut("/UpdateUser/{id}")]
        public IActionResult UpdateUser(Guid id, UserDTO user) {
            return Ok();
        }
        [HttpDelete("/DeleteUser/{id}")]
        public IActionResult DeleteUser(Guid id) {
            var res = _mediator.Send(new DeleteUserCommand(id));
            return Ok(res);
        }
        [HttpGet("/GetUserById/{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var res = _mediator.Send(new GetUserByIdQuery(id));
            return Ok(res);
        }
        [HttpGet("/GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var res = _mediator.Send(new GetAllUsersQuery());
            return Ok(res);
        }
        [HttpGet("/GetAllOrdersOfUsers/{id}")]
        public IActionResult GetAllOrdersOfUsers(Guid id)
        {
            var res = _mediator.Send(new GetAllOrdersOfUserQuery(id));
            return Ok(res);
        }
    }
}
