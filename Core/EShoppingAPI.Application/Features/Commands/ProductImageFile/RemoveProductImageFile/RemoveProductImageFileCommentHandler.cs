using EShoppingAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EShoppingAPI.Application.Features.Commants.ProductImageFile.RemoveProductImageFile
{
    public class RemoveProductImageFileCommentHandler : IRequestHandler<RemoveProductImageFileCommentRequest, RemoveProductImageFileCommentRespons>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        public RemoveProductImageFileCommentHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<RemoveProductImageFileCommentRespons> Handle(RemoveProductImageFileCommentRequest request, CancellationToken cancellationToken)
        {
           Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.productImageFiles)
             .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.id));
           Domain.Entities.ProductImageFile? productImage = product?.productImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.imageId));
            if(productImage != null)
                product?.productImageFiles.Remove(productImage);
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
