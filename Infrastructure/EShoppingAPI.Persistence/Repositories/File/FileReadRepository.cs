using EShoppingAPI.Application.Repositories;
using EShoppingAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Persistence.Repositories.File
{
    public class FileReadRepository : ReadRepository<EShoppingAPI.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(EShoppingAPIDbContext context) : base(context)
        {
        }
    }
}
