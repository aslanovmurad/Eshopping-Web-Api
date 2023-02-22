﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryRequest:IRequest<GetByIdProductQueryRespons>
    {
        public string Id { get; set; }
    }
}