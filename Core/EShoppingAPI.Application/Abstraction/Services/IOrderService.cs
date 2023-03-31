using EShoppingAPI.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Abstraction.Services
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrder createOrder);
        Task<ListOrder> GetAllOrdersAsync(int page,int size);
        Task<SingleOrder> GetOrderById(string id);
    }
}
