using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using POS.Application.DTO;
using POS.Application.Features.ItemFeature.Command;
using System.Net;

namespace POS.AzureFunctions.HTTPTriggers
{
    public class CreateItemHTTPTrigger
    {
        private readonly IMediator _mediator;
        public CreateItemHTTPTrigger(IMediator mediator)
        {
            _mediator = mediator;
        }
        [FunctionName("Admin")]
        public async Task<IActionResult> CreateItem(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "/CreateItem")] HttpRequest req,
            ILogger log)
        {
            var itemDto = await req.ReadFromJsonAsync<ItemDTO>();
            if (itemDto == null)
            {
                return new BadRequestObjectResult("Invalid request body.");
            }

            // Send the command using IMediator
            var result = await _mediator.Send(new CreateItemCommand(itemDto));

            // Return success response
            return new OkObjectResult(result);
        }
    }
}
