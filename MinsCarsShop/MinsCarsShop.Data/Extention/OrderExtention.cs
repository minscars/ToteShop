using Microsoft.EntityFrameworkCore;
using MinsCarsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Data.Extention
{
    public static class OrderExtention
    {
        public static void FillDataOrder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
            new Order()
            {
                Id = 1,
                UserId = 1,
                StatusId = 1,
                OrderTime = DateTime.Now,
                DeliveryTime = DateTime.Now,
            },

            new Order()
            {
                Id = 2,
                UserId = 2,
                StatusId = 2,
                OrderTime = DateTime.Now,
                DeliveryTime = DateTime.Now,
            },

            new Order()
            {
                Id = 3,
                UserId = 1,
                StatusId = 3,
                OrderTime = DateTime.Now,
                DeliveryTime = DateTime.Now,
            },

            new Order()
            {
                Id = 4,
                UserId = 2,
                StatusId = 4,
                OrderTime = DateTime.Now,
                DeliveryTime = DateTime.Now,
            }
            );
        }
    }
}
