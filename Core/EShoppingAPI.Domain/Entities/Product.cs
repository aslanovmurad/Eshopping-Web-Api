﻿using EShoppingAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        //public ICollection<Order> orders { get; set; }
        public ICollection<ProductImageFile> productImageFiles { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
