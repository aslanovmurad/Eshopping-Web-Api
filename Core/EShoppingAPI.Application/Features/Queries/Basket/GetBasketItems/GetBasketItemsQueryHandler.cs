using EShoppingAPI.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Queries.Basket.GetBasketItems
{

    public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQueryRequest, List<GetBasketItemsQueryRespons>>
    {
        readonly IBasketService _basketService;

        public GetBasketItemsQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<List<GetBasketItemsQueryRespons>> Handle(GetBasketItemsQueryRequest request, CancellationToken cancellationToken)
        {
            var basketItem = await _basketService.GetBasketItemsAsync();
            return basketItem.Select(b => new GetBasketItemsQueryRespons
            {
                BasketItemId = b.Id.ToString(),
                Name = b.Product.Name,
                Price = b.Product.Price,
                Quantity = b.Quantity
            }).ToList();
        }
    }
}
