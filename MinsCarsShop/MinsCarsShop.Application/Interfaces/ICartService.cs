using MinsCarsShop.Dto.Cart;
using MinsCarsShop.Dto.Category;
using MinsCarsShop.Dto.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Application.Interfaces
{
	public interface ICartService
	{
		public Task<ApiResult<bool>> AddToCartAsync(CartDTO request);
		public Task<ApiResult<CartDetailDTO>> GetAllInCartAsync();
		public Task<ApiResult<bool>> UpdateAmountAsync(CartDTO request);
		public Task<ApiResult<bool>> DeleteAsync(int ToteId);
	}
}
