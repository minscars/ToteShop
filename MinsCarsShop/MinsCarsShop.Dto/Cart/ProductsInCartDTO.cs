using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Dto.Cart
{
	public class ProductsInCartDTO
	{
		public int ToteId { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int Price { get; set; }
		public int Amount { get; set; }
		public int Subtotal { get; set; }
	}
}
