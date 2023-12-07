using Microsoft.EntityFrameworkCore;
using MinsCarsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Data.Extention
{
    public static class ToteExtention
    {
        public static void FillDataTote(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tote>().HasData(
                new Tote()
                {
                    Id = 1,
                    Name = "Ha Noi",
                    Image = "1.jpg",
                    CategoryId = 1,
                    Price = 9,
					CreatedTime = DateTime.Now,
                },

                new Tote()
                {
                    Id = 2,
                    Name = "Women in front of the windown",
                    Image = "2.jpg",
                    CategoryId = 1,
                    Price = 9,
					CreatedTime = DateTime.Now,
                },
				new Tote()
				{
					Id = 4,
					Name = "Portal to the Cat Dimension",
					Image = "4.jpg",
					CategoryId = 1,
					Price = 9,
					CreatedTime = DateTime.Now,
				},

				new Tote()
				{
					Id = 5,
					Name = "Stay Positive",
					Image = "5.jpg",
					CategoryId = 1,
					Price = 9,
					CreatedTime = DateTime.Now,
				},
				new Tote()
				{
					Id = 6,
					Name = "Couple see the earth",
					Image = "6.jpg",
					CategoryId = 1,
					Price = 9,
					CreatedTime = DateTime.Now,
				},
				new Tote()
				{
					Id = 7,
					Name = "The Bodacious Period",
					Image = "7.jpg",
					CategoryId = 1,
					Price = 9,
					CreatedTime = DateTime.Now,
				},
				new Tote()
				{
					Id = 8,
					Name = "Hide from reality",
					Image = "8.jpg",
					CategoryId = 1,
					Price = 9,
					CreatedTime = DateTime.Now,
				},
				new Tote()
				{
					Id = 9,
					Name = "Blue purple OLDI",
					Image = "9.jpg",
					CategoryId = 1,
					Price = 9,
					CreatedTime = DateTime.Now,
				},
				new Tote()
				{
					Id = 10,
					Name = "Purple Elephent angry",
					Image = "10.jpg",
					CategoryId = 1,
					Price = 9,
					CreatedTime = DateTime.Now,
				},
				new Tote()
				{
					Id = 11,
					Name = "Bag of Holand",
					Image = "11.jpg",
					CategoryId = 1,
					Price = 9,
					CreatedTime = DateTime.Now,
				}
				);
        }
    }
}
