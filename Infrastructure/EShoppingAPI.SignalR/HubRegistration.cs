﻿using EShoppingAPI.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.SignalR
{
    public static class HubRegistration
    {
        public static void MapHub(this WebApplication webApplication)
        {
            webApplication.MapHub<ProductHub>("/product-hub");
            webApplication.MapHub<OrderHub>("/order-hub");
        }
    }
}
