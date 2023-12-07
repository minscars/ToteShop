using Microsoft.AspNetCore.Mvc;
using MinsCarsShop.CustomerSite.Models;
using MinsCarsShop.Dto.Cart;
using MinsCarsShop.Integration;
using Refit;

namespace MinsCarsShop.CustomerSite.Controllers
{
	public class HomeController : Controller
	{
		private readonly IToteAPI _toteAPI;
		private readonly ICategoryAPI _categoryAPI;

		private readonly HomeModel _viewData;
		public HomeController()
		{
			_toteAPI = RestService.For<IToteAPI>("https://localhost:7271");
			_categoryAPI = RestService.For<ICategoryAPI>("https://localhost:7271");
			_viewData = new HomeModel();
		}
		public async Task<IActionResult>  Index()
		{	
			_viewData.Totes = await _toteAPI.GetAll();
			_viewData.Categories = await _categoryAPI.GetAll();
			return View(_viewData);
		}
	}
}
