using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Application.DTO;
using POS.Application.Features.ItemFeature.Command;
using POS.Application.Features.ItemFeature.Query;
using POS.Domain.Entity;
using System;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ItemController(IMediator mediator) { 
            _mediator = mediator;
        }
        [HttpPost("/CreateItem")]
        public IActionResult CreateItem(ItemDTO item) {
            var res = _mediator.Send(new CreateItemCommand(item));
            return Ok(res);
        }
        [HttpDelete("/DeleteItem/{id}")]
        public IActionResult DeleteItem(Guid id)
        {
            var res = _mediator.Send(new DeleteItemCommand(id));
            return Ok(res);
        }
        [HttpGet("/GetAllItems")]
        public IActionResult GetAllItems()
        {
            var res = _mediator.Send(new GetAllItemsQuery());
            return Ok(res);
        }
        [HttpGet("/GetById/{id}")]
        public IActionResult GetById(Guid id)
        {
            var res = _mediator.Send(new GetItemByIdQuery(id));
            return Ok(res);
        }
    }
}
