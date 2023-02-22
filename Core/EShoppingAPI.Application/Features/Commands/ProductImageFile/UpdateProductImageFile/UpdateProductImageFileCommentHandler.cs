using EShoppingAPI.Application.Abstraction.Storage;
using EShoppingAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commants.ProductImageFile.UpdateProductImageFile
{
    public class UpdateProductImageFileCommentHandler : IRequestHandler<UpdateProductImageFileCommentRequest, UpdateProductImageFileCommentRespons>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductImageWriteRepository _productImageWriteRepository;
        readonly IStorageServic _storageServic;
        public UpdateProductImageFileCommentHandler(IProductReadRepository productReadRepository, IProductImageWriteRepository productImageWriteRepository, IStorageServic storageServic)
        {
            _productReadRepository = productReadRepository;
            _productImageWriteRepository = productImageWriteRepository;
            _storageServic = storageServic;
        }


        public async Task<UpdateProductImageFileCommentRespons> Handle(UpdateProductImageFileCommentRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageServic.UploadAsync("photo-images", request.Files);
            Domain.Entities.Product products = await _productReadRepository.GetByIdAsync(request.Id);
            await _productImageWriteRepository.AddRangeAsync(result.Select(r => new Domain.Entities.ProductImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageServic.StorageName,
                product = new List<Domain.Entities.Product>() { products }
            }).ToList());
            await _productImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
