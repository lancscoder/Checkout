using System;
using Microsoft.AspNetCore.Mvc;
using Api.Models.Request;
using MediatR;
using Api.Services.Requests;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/basket/{basketId:Guid}/items")]
    public class ItemsController : Controller
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid basketId)
        {
            var request = new GetItemsRequest { BasketId = basketId };
            var items = await _mediator.Send(request);

            return Ok(items);
        }

        [HttpGet]
        [Route("{id:Guid}", Name = "GetItem")]
        public async Task<IActionResult> Get(Guid basketId, Guid id)
        {
            var request = new GetItemRequest { BasketId = basketId, Id = id };
            var item = await _mediator.Send(request);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item); ;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromRoute]Guid basketId, [FromBody]PostItem requestItem)
        {
            var request = new CreateItemRequest { BasketId = basketId, Item = requestItem };
            var item = await _mediator.Send(request);

            if (item == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("Get", new { basketId = basketId, id = item.Id }, item);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Put([FromRoute]Guid basketId, [FromRoute]Guid id, [FromBody]PutItem requestItem)
        {
            var request = new UpdateItemRequest { BasketId = basketId, Id = id, Item = requestItem };
            var item = await _mediator.Send(request);

            if (item == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]Guid basketId)
        {
            var request = new DeleteItemsRequest { BasketId = basketId };
            await _mediator.Send(request);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid basketId, [FromRoute]Guid id)
        {
            var request = new DeleteItemRequest { BasketId = basketId, Id = id };
            await _mediator.Send(request);

            return NoContent();
        }
    }
}
