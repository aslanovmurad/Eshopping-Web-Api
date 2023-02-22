using EShoppingAPI.Application.Repositories;
using EShoppingAPI.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var tolalCount = _productReadRepository.Getall(false).Count();
            var product = _productReadRepository.Getall(false).Skip(request.Page * request.Size).Take(request.Size).Select(p => new
            {
                p.Id,
                p.Price,
                p.Name,
                p.Stock,
                p.CreateDate,
                p.UpdateDate
            }).ToList();

            return new()
            {
                Products = product,
                TotalCount = tolalCount
            };
        }
    }
}
