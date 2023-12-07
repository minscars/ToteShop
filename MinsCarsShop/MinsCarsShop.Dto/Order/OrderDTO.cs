using MinsCarsShop.Dto.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Dto.Order
{
    public class OrderDTO
    {
        public int UserId { get; set; } 
        public List<CartDTO> CartItems { get; set; }
        public decimal Total { get; set; }
    }
}
