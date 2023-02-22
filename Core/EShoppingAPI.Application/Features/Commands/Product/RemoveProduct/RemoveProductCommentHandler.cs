using EShoppingAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commants.Product.RemoveProduct
{
    public class RemoveProductCommentHandler : IRequestHandler<RemoveProductCommentRequest, RemoveProductCommentRespons>
    {
        readonly IProductWriteRepository _productWriteRepository;

        public RemoveProductCommentHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<RemoveProductCommentRespons> Handle(RemoveProductCommentRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.RemoveAsync(request.Id);
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
