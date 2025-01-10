using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using POS.Application.DTO;
using POS.Application.Features.ItemFeature.Command;
using POS.Application.Features.ItemFeature.Query;
using POS.Domain.Entity;
using System;
using System.Linq;
using System.Security.Claims;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "AdminPolicy")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("/CreateItem")]
        public IActionResult CreateItem(ItemDTO item)
        {
            var res = _mediator.Send(new CreateItemCommand(item));
            return Ok(res);
        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("/DeleteItem/{id}")]
        public IActionResult DeleteItem(Guid id)
        {  
            var res = _mediator.Send(new DeleteItemCommand(id));
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpGet("/GetAllItems")]
        public IActionResult GetAllItems()
        {
            var claims = User.Claims.FirstOrDefault(o=>o.Type==ClaimTypes.Role);
            Console.WriteLine(claims);
            var res = _mediator.Send(new GetAllItemsQuery());
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpGet("/GetById/{id}")]
        public IActionResult GetById(Guid id)
        {
            var res = _mediator.Send(new GetItemByIdQuery(id));
            return Ok(res);
        }
    }
}
