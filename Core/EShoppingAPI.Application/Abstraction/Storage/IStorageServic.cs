using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Abstraction.Storage
{
    public interface IStorageServic: IStorage
    {
        public string StorageName { get; }
    }
}
