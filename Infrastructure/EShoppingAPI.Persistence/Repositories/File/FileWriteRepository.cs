using EShoppingAPI.Application.Repositories;
using EShoppingAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<EShoppingAPI.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(EShoppingAPIDbContext context) : base(context)
        {
        }
    }
}
