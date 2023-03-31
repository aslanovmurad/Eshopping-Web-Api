using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdQueryRequest:IRequest<GetOrderByIdQueryRespons>
    {
        public string Id { get; set; }
    }
}
