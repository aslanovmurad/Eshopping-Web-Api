using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commants.Product.RemoveProduct
{
    public class RemoveProductCommentRequest:IRequest<RemoveProductCommentRespons>
    {
        public string Id { get; set; }
    }
}
