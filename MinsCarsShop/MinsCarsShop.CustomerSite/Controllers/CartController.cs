using Microsoft.AspNetCore.Mvc;
using MinsCarsShop.CustomerSite.Models;
using MinsCarsShop.Dto.Cart;
using MinsCarsShop.Integration;
using Refit;

namespace MinsCarsShop.CustomerSite.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartAPI _cartAPI;
        private readonly IOrderAPI _orderAPI;
        private readonly CartModel _viewData;

        public CartController()
        {
            _cartAPI = RestService.For<ICartAPI>("https://localhost:7271/");
            _orderAPI = RestService.For<IOrderAPI>("https://localhost:7271/");
            _viewData = new CartModel();
        }
		public async Task<IActionResult> Index()
        {
            var carts = await _cartAPI.GetAll();
            _viewData.Carts = carts;
            return View(_viewData);
        }
		public async Task<IActionResult> AddToCart(int id, int amount)
		{
            CartDTO request = new CartDTO()
            {
                ToteId = id,
                Amount = amount
            };
            await _cartAPI.AddToCartAsync(request);
			return RedirectToAction("Home/Index");
		}
         
        public async Task<IActionResult> UpdateAmount(int id, int amount)
        {
            CartDTO request = new CartDTO()
            {
                ToteId = id,
                Amount = amount 
            };
            await _cartAPI.UpdateAmountAsync(request);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _cartAPI.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Order()
        {
            await _orderAPI.OrderAsync();
            return RedirectToAction("Index");
        }
	}
}
