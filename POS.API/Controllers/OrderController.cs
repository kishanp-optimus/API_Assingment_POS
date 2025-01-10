using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using POS.Application.DTO;
using POS.Application.Features.OrderFeature.Command;
using POS.Application.Features.OrderFeature.Query;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IMediator _mediator { get; set; }
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Policy = "UserPolicy")]
        [HttpPost("/CreateOrder")]
        public IActionResult CreateOrder(OrderDTO order)
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            if (id == null)
            {
                return Unauthorized("User ID claim not found in token.");
            }
            var userId = Guid.Parse(id);
            var res = _mediator.Send(new CreateOrderCommand(userId, order));
            return Ok(res);
        }
        [Authorize(Policy = "UserPolicy")]
        [HttpDelete("/DeleteOrder")]
        public IActionResult DeleteOrder(Guid id)
        {
            var res = _mediator.Send(new DeleteOrderCommand(id));
            return Ok(res);
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("/GetAll")]
        public IActionResult GetAll()
        {
            var res = _mediator.Send(new GetAllQuery());
            return Ok(res);
        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpPut("/UpdateOrderStage")]
        public IActionResult UpdateOrderStage(Guid id, string stage)
        {
            var res = _mediator.Send(new UpdateOrderStageCommand(id, stage));
            return Ok(res);
        }
    }
}
