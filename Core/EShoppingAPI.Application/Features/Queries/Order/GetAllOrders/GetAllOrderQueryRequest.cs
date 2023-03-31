﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrderQueryRequest : IRequest<GetAllOrderQueryRespons>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
