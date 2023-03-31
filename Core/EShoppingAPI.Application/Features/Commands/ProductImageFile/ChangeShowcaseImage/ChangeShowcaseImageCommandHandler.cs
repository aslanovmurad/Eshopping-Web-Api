using EShoppingAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandRespons>
    {
        readonly IProductImageWriteRepository _productImageWriteRepository;

        public ChangeShowcaseImageCommandHandler(IProductImageWriteRepository productImageWriteRepository)
        {
            _productImageWriteRepository = productImageWriteRepository;
        }

        public async Task<ChangeShowcaseImageCommandRespons> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            var query = _productImageWriteRepository.Table
                  .Include(p => p.product)
                .SelectMany(p => p.product, (pif, p) => new
                {
                    pif,
                    p
                });


            var data = await query.FirstOrDefaultAsync(p => p.p.Id == Guid.Parse(request.ProductId) && p.pif.showcase);
            if (data !=null)
             data.pif.showcase = false;

            var image = await query.FirstOrDefaultAsync(p => p.pif.Id == Guid.Parse(request.ImageId));
            if(image !=null)
             image.pif.showcase = true;

            await _productImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
