using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commants.ProductImageFile.RemoveProductImageFile
{
    public class RemoveProductImageFileCommentRequest:IRequest<RemoveProductImageFileCommentRespons>
    {
        public string id { get; set; }

        public string? imageId { get; set; }
    }
}
