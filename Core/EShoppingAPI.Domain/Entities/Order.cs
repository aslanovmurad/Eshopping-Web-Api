﻿using EShoppingAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Domain.Entities
{
    public class Order:BaseEntity
    {
        public Guid customerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Product> products { get; set; }
        public Customer customer { get; set; }
    }
}
