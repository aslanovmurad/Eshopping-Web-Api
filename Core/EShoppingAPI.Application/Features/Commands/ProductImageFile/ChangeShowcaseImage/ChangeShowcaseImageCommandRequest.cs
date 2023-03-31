using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandRequest:IRequest<ChangeShowcaseImageCommandRespons>
    {
        public string ImageId { get; set; }
        public string ProductId { get; set; }
    }
}
