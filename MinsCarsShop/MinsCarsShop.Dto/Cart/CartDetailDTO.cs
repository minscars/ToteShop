using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Dto.Cart
{
	public class CartDetailDTO
	{
		public List<ProductsInCartDTO> ProductsInCart { get; set; }
		public decimal Total { get; set; }
	}
}
