using Microsoft.EntityFrameworkCore;
using MinsCarsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Data.Extention
{
    public static class OrderDetailExtention
    {
        public static void FillDataOrderDetail(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasData(
            new OrderDetail()
            {
                OrderId = 1,
                ToteId = 1,
                Amount = 2,
                OrderPrice = 138000
            },

            new OrderDetail()
            {
                OrderId = 2,
                ToteId = 2,
                Amount = 10,
                OrderPrice = 999000
            }
            );
        }
    }
}
