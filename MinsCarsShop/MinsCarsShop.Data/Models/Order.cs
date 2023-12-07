using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? OrderTime { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public decimal Total { get; set; }
        public Status Status { get; set; }
        public User User { get; set; }
        public int StatusId { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
