using EShoppingAPI.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryRespons>
    {
        readonly IOrderService _orderService;

        public GetOrderByIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetOrderByIdQueryRespons> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
        {
          var data = await _orderService.GetOrderById(request.Id);
            return new()
            {
                Id = data.Id,
                Address = data.Address,
                Description = data.Description,
                CreateDate = data.CreateDate,
                OrderCode = data.OrderCode,
                BasketItems = data.BasketItems
            };

        }
    }
}
