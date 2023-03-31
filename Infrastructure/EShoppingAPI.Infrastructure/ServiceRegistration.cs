using EShoppingAPI.Application.Abstraction.Services;
using EShoppingAPI.Application.Abstraction.Storage;
using EShoppingAPI.Application.Abstraction.Token;
using EShoppingAPI.Infrastructure.Enums;
using EShoppingAPI.Infrastructure.Services;
using EShoppingAPI.Infrastructure.Services.Storage;
using EShoppingAPI.Infrastructure.Services.Storage.Azure;
using EShoppingAPI.Infrastructure.Services.Storage.Local;
using EShoppingAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IStorageServic, StorageSarvic>();
            serviceDescriptors.AddScoped<ITokenHandler,TokenHandler>();
            serviceDescriptors.AddScoped<IMailService, MailService>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceDescriptors) where T : Storage, IStorage
        {
            serviceDescriptors.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceDescriptors,StorageType storgaeType) 
        {
            switch (storgaeType)
            {
                case StorageType.Local:
                    serviceDescriptors.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceDescriptors.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    break;
                default:
                    serviceDescriptors.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
