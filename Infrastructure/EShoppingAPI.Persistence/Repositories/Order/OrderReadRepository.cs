using EShoppingAPI.Application.Repositories;
using EShoppingAPI.Domain.Entities;
using EShoppingAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(EShoppingAPIDbContext context) : base(context)
        {
        }
    }
}
