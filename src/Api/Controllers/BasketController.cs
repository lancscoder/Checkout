using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Api.Services.Requests;

namespace Api.Controllers
{
    [Route("api/basket")]
    public class BasketController : Controller
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id:Guid}", Name = "GetBasket")]
        public async Task<IActionResult> Get(Guid id)
        {
            var request = new GetBasketRequest { Id = id };
            var basket = await _mediator.Send(request);

            if (basket == null)
            {
                return NotFound();
            }

            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var request = new CreateBasketRequest();
            var basket = await _mediator.Send(request);

            return CreatedAtAction("Get", new { id = basket.Id }, basket);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteBasketRequest();
            await _mediator.Send(request);

            return NoContent();
        }
    }
}
