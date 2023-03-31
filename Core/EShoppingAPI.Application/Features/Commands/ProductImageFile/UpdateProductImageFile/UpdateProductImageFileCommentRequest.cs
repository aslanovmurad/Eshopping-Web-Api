using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commants.ProductImageFile.UpdateProductImageFile
{
    public class UpdateProductImageFileCommentRequest:IRequest<UpdateProductImageFileCommentRespons>
    {
        public string Id { get; set; }

        public IFormFileCollection? Files { get; set; }
    }
}
