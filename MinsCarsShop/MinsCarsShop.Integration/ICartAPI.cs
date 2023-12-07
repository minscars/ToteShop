using MinsCarsShop.Data.Models;
using MinsCarsShop.Dto.Cart;
using MinsCarsShop.Dto.Constants;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Integration
{
	public interface ICartAPI
	{
		[Get("/api/Carts")]
		public Task<CartDetailDTO> GetAll();

		[Post("/api/Carts")]
		public Task<bool> AddToCartAsync(CartDTO request);

		[Put("/api/Carts")]
		public Task<bool> UpdateAmountAsync(CartDTO request);

		[Delete("/api/Carts/{Id}")]
		public Task<bool> DeleteAsync(int Id);
	}
}
