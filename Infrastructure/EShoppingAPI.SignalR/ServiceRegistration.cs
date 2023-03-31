using EShoppingAPI.Application.Abstraction.Hub;
using EShoppingAPI.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignlRServices(this IServiceCollection collaction)
        {
            collaction.AddTransient<IProductHubSerice, ProductHubService>();
            collaction.AddTransient<IOrderHubService, OrderHubService>();
            collaction.AddSignalR();
        }
    }
}
