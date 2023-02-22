using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Queries.ProductImageFile
{
    public class GetProductImageFileQueryRequest:IRequest<List<GetProductImageFileQueryRespons>>
    {
        public string id { get; set; }
    }
}
