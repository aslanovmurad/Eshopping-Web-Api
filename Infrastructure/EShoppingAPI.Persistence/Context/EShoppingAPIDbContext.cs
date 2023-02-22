using EShoppingAPI.Domain.Entities;
using EShoppingAPI.Domain.Entities.Common;
using EShoppingAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Persistence.Context
{
    public class EShoppingAPIDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public EShoppingAPIDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Domain.Entities.File> files { get; set; }
        public DbSet<ProductImageFile> productImageFiles { get; set; }
        public DbSet<InvoiceFile> invoiceFiles { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
                    _=>DateTime.UtcNow
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
