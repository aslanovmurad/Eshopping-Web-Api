using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Domain.Entities
{
    public class ProductImageFile:File
    {
        public ICollection<Product> product { get; set; }
    }
}
