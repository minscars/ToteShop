using Microsoft.AspNetCore.Mvc;
using MinsCarsShop.CustomerSite.Models;
using MinsCarsShop.Dto.Tote;
using MinsCarsShop.Integration;
using Refit;

namespace MinsCarsShop.CustomerSite.Controllers
{
	public class ShopController : Controller
	{
		private readonly IToteAPI _toteAPI;
		private readonly ICategoryAPI _categoryAPI;

		private readonly ShopModel _viewData;

		public ShopController()
		{
			_toteAPI = RestService.For<IToteAPI>("https://localhost:7271");
			_categoryAPI = RestService.For<ICategoryAPI>("https://localhost:7271");
			_viewData = new ShopModel();
		}
		public async Task<IActionResult>  Index()
		{
			_viewData.Totes = await _toteAPI.GetAll();
			_viewData.Categories = await _categoryAPI.GetAll();

			return View(_viewData);
		}

		public async Task<IActionResult> Category(int Id)
		{
			_viewData.Totes = await _toteAPI.GetByCategoryId(Id);
			_viewData.Categories = await _categoryAPI.GetAll();
			return View(_viewData);
		}

		public async Task<IActionResult> Detail(int Id)
		{
			_viewData.Tote = await _toteAPI.GetById(Id);
			_viewData.Categories = await _categoryAPI.GetAll();

			return View(_viewData);
		}

		public async Task<IActionResult> Search(string Key)
		{
			_viewData.Totes = await _toteAPI.FindByKey(Key);
			return View(_viewData);
		}
	}
}
