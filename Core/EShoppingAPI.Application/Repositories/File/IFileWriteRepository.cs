using EShoppingAPI.Application.Resitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Repositories
{
    public interface IFileWriteRepository: IWriteRepository<EShoppingAPI.Domain.Entities.File>
    {
    }
}
