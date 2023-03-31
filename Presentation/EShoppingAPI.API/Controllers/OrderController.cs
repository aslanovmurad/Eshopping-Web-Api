using EShoppingAPI.Application.Features.Commands.Order.CreateOrder;
using EShoppingAPI.Application.Features.Queries.Order.GetAllOrders;
using EShoppingAPI.Application.Features.Queries.Order.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrderController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOrderById([FromRoute]GetOrderByIdQueryRequest getOrderByIdQueryRequest)
        {
            GetOrderByIdQueryRespons respons = await _mediator.Send(getOrderByIdQueryRequest);
            return Ok(respons);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery]GetAllOrderQueryRequest getAllOrderQueryRequest)
        {
            GetAllOrderQueryRespons respons = await _mediator.Send(getAllOrderQueryRequest);
            return Ok(respons);

        }
        
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandRespons respons = await _mediator.Send(createOrderCommandRequest);
            return Ok(respons);
        }
    }
}
