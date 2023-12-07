using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Data.Models
{
    public class Cart
    {
        public int ToteId { get; set; }
        public int Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Tote Tote { get; set; }
        public bool IsDeleted { get; set; }
    }
}
