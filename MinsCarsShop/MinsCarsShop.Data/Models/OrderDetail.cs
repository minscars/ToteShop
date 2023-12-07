using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Data.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ToteId { get; set; }
        public int Amount { get; set; }
        public int OrderPrice { get; set; }
        public Order Order { get; set; }
        public Tote Tote { get; set; }

    }
}
