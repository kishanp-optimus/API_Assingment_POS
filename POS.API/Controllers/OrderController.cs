using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using POS.Application.DTO;
using POS.Application.Features.OrderFeature.Command;
using POS.Application.Features.OrderFeature.Query;
using System;

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
        [HttpPost("/CreateOrder")]
        public IActionResult CreateOrder(OrderDTO order)
        {
            var res = _mediator.Send(new CreateOrderCommand(order));
            return Ok(res);
        }
        [HttpDelete("/DeleteOrder")]
        public IActionResult DeleteOrder(Guid id)
        {
            var res = _mediator.Send(new DeleteOrderCommand(id));
            return Ok(res);
        }
        [HttpGet("/GetAll")]
        public IActionResult GetAll()
        {
            var res = _mediator.Send(new GetAllQuery());
            return Ok(res);
        }
        [HttpPut("/UpdateOrderStage")]
        public IActionResult UpdateOrderStage(Guid id, string stage) {
            var res = _mediator.Send(new UpdateOrderStageCommand(id, stage));
            return Ok(res);
        }
    }
}
