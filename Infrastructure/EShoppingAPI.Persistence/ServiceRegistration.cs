using EShoppingAPI.Application.Abstraction.Services;
using EShoppingAPI.Application.Abstraction.Services.Authentications;
using EShoppingAPI.Application.Repositories;
using EShoppingAPI.Domain.Entities.Identity;
using EShoppingAPI.Persistence.Context;
using EShoppingAPI.Persistence.Repositories;
using EShoppingAPI.Persistence.Repositories.File;
using EShoppingAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<EShoppingAPIDbContext>(ops => ops.UseSqlServer(Configuration.ConfigurationString));
            services.AddIdentity<AppUser, AppRole>(op =>
            {
                op.Password.RequiredLength = 3;
                op.Password.RequireNonAlphanumeric = false;
                op.Password.RequireDigit = false;
                op.Password.RequireLowercase = false;
                op.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<EShoppingAPIDbContext>()
            .AddDefaultTokenProviders();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductImageReadRepository, ProductImageReadRepository>();
            services.AddScoped<IProductImageWriteRepository, ProductImageWriteRepository>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AutherService>();
            services.AddScoped<IExternalAuthentication, AutherService>();
            services.AddScoped<IInternalAuthentication, AutherService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
