using Microsoft.AspNetCore.Mvc;
using MinsCarsShop.AdminSite.Models;
using MinsCarsShop.Dto.Category;
using MinsCarsShop.Dto.Tote;
using MinsCarsShop.Integration;
using Refit;
using System.Diagnostics;

namespace MinsCarsShop.AdminSite.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ICategoryAPI _categoryAPI;

        private readonly ProductModel _viewData;

        public HomeController()
		{
            _categoryAPI = RestService.For<ICategoryAPI>("https://localhost:7271");
            _viewData = new ProductModel();
        }

        public async Task<IActionResult> Index()
        {
            _viewData.Categories = await _categoryAPI.GetAll();
            return View(_viewData);
        }

        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        public async Task<IActionResult> Add(CreateCateDTO request)
        {
            Stream imageStream = request.Image.OpenReadStream();
            StreamPart imageStreamPart = new StreamPart(imageStream, request.Image.FileName, request.Image.ContentType);
            await _categoryAPI.CreateAsync(imageStreamPart, request.Name);
            return RedirectToAction("Index");
        }
    }
}