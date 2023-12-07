using Microsoft.EntityFrameworkCore;
using MinsCarsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Data.Extention
{
    public static class StatusExtention
    {
        public static void FillDataStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status() { Id = 1, Name = "Chưa xử lý" },
                new Status() { Id = 2, Name = "Đang chuẩn bị" },
                new Status() { Id = 3, Name = "Đang giao hàng" },
                new Status() { Id = 4, Name = "Giao hàng thành công" }
            );
        }
    }
}
