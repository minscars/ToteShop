using Microsoft.EntityFrameworkCore;
using MinsCarsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Data.Extention
{
    public static class CategoryExtention
    {
        public static void FillDataCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Canvas Tote",
                    Image = "1.jpg",
                },

                new Category()
                {
                    Id = 2,
                    Name = "Jean Tote",
                    Image = "2.jpg",
                }
                );
        }
    }
}
