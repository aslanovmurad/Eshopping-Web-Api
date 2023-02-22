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
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(EShoppingAPIDbContext context) : base(context)
        {
        }
    }
}
