using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commands.Basket.UpdateQuantity
{
    public class UpdateQuantityCommandRequest:IRequest<UpdateQuantityCommandRespons>
    {
        public string BasketItemId { get; set; }
        public int Quantity { get; set; }
    }
}
