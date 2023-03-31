using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdQueryRespons
    {
        public string Address { get; set; }
        public object BasketItems { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string OrderCode { get; set; }
    }
}
