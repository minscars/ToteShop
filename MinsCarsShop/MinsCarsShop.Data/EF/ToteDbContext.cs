using Microsoft.EntityFrameworkCore;
using MinsCarsShop.Data.Configurations;
using MinsCarsShop.Data.Extention;
using MinsCarsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Data.EF
{
    public class ToteDbContext : DbContext
    {
        public DbSet<Category> Categories { set; get;  }
        public DbSet<Tote> Totes { set; get; }
        public DbSet<Status> Statuses  { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<Cart> Carts { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }

        public ToteDbContext(DbContextOptions<ToteDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig())
                        .ApplyConfiguration(new ToteConfig())
                        .ApplyConfiguration(new StatusConfig())
                        .ApplyConfiguration(new UserConfig())
                        .ApplyConfiguration(new CartConfig())
                        .ApplyConfiguration(new OrderConfig())
                        .ApplyConfiguration(new OrderDetailConfig());

            modelBuilder.FillDataTote();
            modelBuilder.FillDataCategory();
            modelBuilder.FillDataCart();
            modelBuilder.FillDataStatus();
            modelBuilder.FillDataOrder();
            modelBuilder.FillDataOrderDetail();
            modelBuilder.FillDataUser();

        }


    }
}
