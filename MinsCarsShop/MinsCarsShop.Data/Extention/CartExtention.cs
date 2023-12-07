using Microsoft.EntityFrameworkCore;
using MinsCarsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Data.Extention
{
    public static class CartExtention
    {
        public static void FillDataCart(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().HasData(
            new Cart()
            {
                UserId = 1,
                ToteId = 1,
                Amount = 2,
            },
            new Cart()
            {
                UserId = 1,
                ToteId = 2,
                Amount = 10,
            }
            );
        }
    }
}
