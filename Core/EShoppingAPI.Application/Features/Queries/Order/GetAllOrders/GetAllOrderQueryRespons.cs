using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrderQueryRespons
    {
        public int TotelOrderCount { get; set; }
        public object Orders { get; set; }
    }
}
