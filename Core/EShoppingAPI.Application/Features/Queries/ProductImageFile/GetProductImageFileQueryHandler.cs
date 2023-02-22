using EShoppingAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Queries.ProductImageFile
{
    public class GetProductImageFileQueryHandler : IRequestHandler<GetProductImageFileQueryRequest, List<GetProductImageFileQueryRespons>>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetProductImageFileQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<List<GetProductImageFileQueryRespons>> Handle(GetProductImageFileQueryRequest request, CancellationToken cancellationToken)
        {
           Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.productImageFiles)
               .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.id));
            return product?.productImageFiles.Select(p => new GetProductImageFileQueryRespons
            {
                FileName = p.FileName,
                Id = p.Id
            }).ToList();
        }
    }
}
