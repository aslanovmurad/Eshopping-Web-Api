using EShoppingAPI.Application.Abstraction.Services;
using EShoppingAPI.Application.DTOs.Order;
using EShoppingAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        public async Task CreateOrder(CreateOrder createOrder)
        {
            var ordercode = (new Random().NextDouble() * 10000).ToString();
            ordercode = ordercode.Substring(ordercode.IndexOf(".") + 1, ordercode.Length - ordercode.IndexOf(".") - 1);
            await _orderWriteRepository.AddAsync(new()
            {
                Address = createOrder.Address,
                Id = Guid.Parse(createOrder.BasketId),
                Description = createOrder.Description,
                OrderCode = ordercode
            });
            await _orderWriteRepository.SaveAsync();
        }

        public async Task<ListOrder> GetAllOrdersAsync(int page, int size)
        {
            var query = _orderReadRepository.Table.Include(o => o.Basket)
                   .ThenInclude(b => b.User)
                   .Include(o => o.Basket)
                   .ThenInclude(b => b.BasketItems)
                   .ThenInclude(b => b.Product);


            var data = query.Skip(page * size).Take(size);

            return new()
            {
                TotalOrderCount = await query.CountAsync(),
                Orders = await data.Select(o => new
                {
                    Id = o.Id,
                    CreateDate = o.CreateDate,
                    OrderCode = o.OrderCode,
                    TotalPrice = o.Basket.BasketItems.Sum(b => b.Product.Price * b.Quantity),
                    UserName = o.Basket.User.UserName
                }).ToListAsync()
            };
        }

        public async Task<SingleOrder> GetOrderById(string id)
        {
            var data = await _orderReadRepository.Table
                .Include(o => o.Basket)
                .ThenInclude(b => b.BasketItems)
                .ThenInclude(b => b.Product)
                .FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));
            return new()
            {
                Id = data.Id.ToString(),
                BasketItems = data.Basket.BasketItems.Select(b => new
                {
                    b.Product.Name,
                    b.Product.Price,
                    b.Quantity
                }),
                Address = data.Address,
                CreateDate = data.CreateDate,
                Description = data.Description,
                OrderCode = data.OrderCode
                
            };
        }
    }
}
