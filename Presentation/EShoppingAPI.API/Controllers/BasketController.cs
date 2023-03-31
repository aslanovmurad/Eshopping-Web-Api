using EShoppingAPI.Application.Features.Commands.Basket.AddItemToBasket;
using EShoppingAPI.Application.Features.Commands.Basket.RemoveBasketItem;
using EShoppingAPI.Application.Features.Commands.Basket.UpdateQuantity;
using EShoppingAPI.Application.Features.Queries.Basket.GetBasketItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class BasketController : ControllerBase
    {
        readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasketItem([FromQuery]GetBasketItemsQueryRequest getBasketItemsQueryRequest) 
        {
            List<GetBasketItemsQueryRespons> respons = await _mediator.Send(getBasketItemsQueryRequest);
            return Ok(respons);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest addItemToBasketCommandRequest)
        {
            AddItemToBasketCommandRespons respons = await _mediator.Send(addItemToBasketCommandRequest);
            return Ok(respons);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest updateQuantityCommandRequest)
        {
            UpdateQuantityCommandRespons respons = await _mediator.Send(updateQuantityCommandRequest);
            return Ok(respons);
        }

        [HttpDelete("{BasketItemId}")]
        public async Task<IActionResult> RemoveBasket([FromRoute]RemoveBasketItemCommandRequest removeBasketItemCommandRequest)
        {
            RemoveBasketItemCommandRespons respons = await _mediator.Send(removeBasketItemCommandRequest);
            return Ok(respons);
        }


    }
}
