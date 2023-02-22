using EShoppingAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commants.Product.UpdateProduct
{
    public class UpdateProductCommentHandler : IRequestHandler<UpdateProductCommentRequest, UpdateProductCommentRespons>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        public UpdateProductCommentHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<UpdateProductCommentRespons> Handle(UpdateProductCommentRequest request, CancellationToken cancellationToken)
        {
           EShoppingAPI.Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id);
            product.Stock = request.Stock;
            product.Price = request.Price;
            product.Name = request.Name;
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
