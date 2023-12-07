using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinsCarsShop.Application.Interfaces;
using MinsCarsShop.Application.Services;
using MinsCarsShop.Dto.Cart;
using MinsCarsShop.Dto.Constants;
using static System.Net.Mime.MediaTypeNames;

namespace MinsCarsShop.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartsController : ControllerBase
	{
		private readonly ICartService _cartService;
		public CartsController(ICartService cartService)
		{
			_cartService = cartService;
		}
		private string setImageName(string currentName)
		{
			return String.Format("{0}://{1}{2}/images/Totes/{3}", Request.Scheme, Request.Host, Request.PathBase, currentName);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> AddToCart(CartDTO request)
		{
			var result = await _cartService.AddToCartAsync(request);
			if (result.StatusCode == 400)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetAll()
		{
			var result = await _cartService.GetAllInCartAsync();
			result?.Data?.ProductsInCart.ForEach(s => s.Image = setImageName(s.Image));
			return Ok(result?.Data);
		}
		[HttpPut()]
        [AllowAnonymous]
		public async Task<IActionResult> UpdateAmount([FromBody] CartDTO request)
		{
			var result = await _cartService.UpdateAmountAsync(request);
            if (result.StatusCode == 400)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
		[HttpDelete("{Id}")]
		[AllowAnonymous]
		public async Task<IActionResult> Delete([FromRoute] int Id)
		{
			var result = await _cartService.DeleteAsync(Id);
			if (result.StatusCode == 400)
			{
				return BadRequest(result.Message);
			}
			return Ok(result.Message);
		}
	}
}
