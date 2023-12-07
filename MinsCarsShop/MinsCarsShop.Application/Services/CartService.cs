using Azure.Core;
using Microsoft.EntityFrameworkCore;
using MinsCarsShop.Application.Interfaces;
using MinsCarsShop.Data.EF;
using MinsCarsShop.Data.Models;
using MinsCarsShop.Dto.Cart;
using MinsCarsShop.Dto.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Application.Services
{
	public class CartService : ICartService
	{
		private readonly ToteDbContext _context;
		public CartService(ToteDbContext context)
		{
			_context = context;
		}

		public async Task<ApiResult<bool>> AddToCartAsync(CartDTO request)
		{
			//request toteId, amount
			if (request == null)
			{
				return new ApiResult<bool>(false)
				{
					Message = "Something went wrong!",
					StatusCode = 400
				};
			}
			var check = await _context.Carts.Where(c => c.UserId == 1 && c.ToteId == request.ToteId).FirstOrDefaultAsync();
			if (check==null)
			{
				var cart = new Cart()
				{
					ToteId = request.ToteId,
					Amount = request.Amount,
					UserId = 1,
				};
				await _context.Carts.AddAsync(cart);
				await _context.SaveChangesAsync();
			}
			else
			{
				var cart = new CartDTO()
				{
					ToteId = request.ToteId,
					Amount = request.Amount+1
				};
				await UpdateAmountAsync(cart);
			}

			return new ApiResult<bool>(true)
			{
				Message = "Add to cart successfully!",
				StatusCode = 200
			};
		}

		public async Task<ApiResult<CartDetailDTO>> GetAllInCartAsync()
		{
			var productsInCarts = await _context.Carts.Where(c => c.UserId == 1 && c.IsDeleted==false).Select(c => new ProductsInCartDTO()
			{
				ToteId = c.ToteId,
				Image = c.Tote.Image,
				Name = c.Tote.Name,
				Price = c.Tote.Price,
				Amount = c.Amount,
				Subtotal = c.Amount * c.Tote.Price,
			}).ToListAsync();
			var total = productsInCarts.Sum(c => c.Subtotal);
			var cart = new CartDetailDTO()
			{
				ProductsInCart = productsInCarts,
				Total = total,
			};

			return new ApiResult<CartDetailDTO>(cart)
			{
				Message = "",
				StatusCode = 200
			};
		}

		public async Task<ApiResult<bool>> UpdateAmountAsync(CartDTO request)
		{
            if (request == null)
            {
                return new ApiResult<bool>(false)
                {
                    Message = "Something went wrong!",
                    StatusCode = 400
                };
            }

			var cart = await _context.Carts.Where(c => c.UserId == 1 && c.ToteId == request.ToteId).FirstOrDefaultAsync();
			cart.Amount = request.Amount;
            await _context.SaveChangesAsync();

			return new ApiResult<bool>(true)
            {
                Message = "Update amount successfully!",
                StatusCode = 200
            };
        }

		public async Task<ApiResult<bool>> DeleteAsync(int ToteId)
		{
			var cart = await _context.Carts.Where(c => c.UserId == 1 && c.ToteId == ToteId).FirstOrDefaultAsync();
			if (cart == null)
			{
				return new ApiResult<bool>(false)
				{
					Message = "Something went wrong!",
					StatusCode = 400
				};
			}
			cart.IsDeleted= true;
			await _context.SaveChangesAsync();
			return new ApiResult<bool>(true)
			{
				Message = "Delete successfully!",
				StatusCode = 200
			};
		}
	}
}
