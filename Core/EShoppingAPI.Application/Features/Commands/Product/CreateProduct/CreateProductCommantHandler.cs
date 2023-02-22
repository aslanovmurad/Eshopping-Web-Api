using EShoppingAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commants.Product.CreateProduct
{
    public class CreateProductCommantHandler : IRequestHandler<CreateProductCommantRequest, CreateProductCommantRespons>
    {
        readonly IProductWriteRepository _productWriteRepository;

        public CreateProductCommantHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<CreateProductCommantRespons> Handle(CreateProductCommantRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price
            });
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
