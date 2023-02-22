using EShoppingAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Domain.Entities
{
    public class File:BaseEntity
    {
        [NotMapped]
        public override DateTime UpdateDate { get => base.UpdateDate; set => base.UpdateDate = value; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Storage { get; set; }
    }
}
