using Microsoft.AspNetCore.Mvc;
using MinsCarsShop.AdminSite.Models;
using MinsCarsShop.Dto.Image;
using MinsCarsShop.Dto.Tote;
using MinsCarsShop.Integration;
using Refit;

namespace MinsCarsShop.AdminSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IToteAPI _toteAPI;
        private readonly ICategoryAPI _categoryAPI;

        private readonly ProductModel _viewData;

        public ProductController()
        {
            _toteAPI = RestService.For<IToteAPI>("https://localhost:7271");
            _categoryAPI = RestService.For<ICategoryAPI>("https://localhost:7271");
            _viewData = new ProductModel();
        }
        public async Task<IActionResult> Index()
        {
            _viewData.Totes = await _toteAPI.GetAll();
            _viewData.Categories = await _categoryAPI.GetAll();
            return View(_viewData);
        }

        public async Task<IActionResult> EditProduct(int Id)
        {
            _viewData.Tote = await _toteAPI.GetById(Id);
            _viewData.Categories = await _categoryAPI.GetAll();

            return View(_viewData);
        }

        public async Task<IActionResult> DeleteProduct(int Id)
        {
            _viewData.Tote = await _toteAPI.GetById(Id);
            _viewData.Categories = await _categoryAPI.GetAll();

            return View(_viewData);
        }

        public async Task<IActionResult> Add(CreateToteDTO request)
        {
            Stream imageStream = request.Image.OpenReadStream();
            StreamPart imageStreamPart = new StreamPart(imageStream, request.Image.FileName, request.Image.ContentType);
            await _toteAPI.CreateAsync(imageStreamPart, request.Name, request.Price, request.CategoryId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(EditToteDTO request)
        {
            if (request.Image!=null)
            {
                Stream imageStream = request.Image.OpenReadStream();
                StreamPart imageStreamPart = new StreamPart(imageStream, request.Image.FileName, request.Image.ContentType);
                await _toteAPI.EditAsync(imageStreamPart, request.Id, request.Name, request.Price, request.CategoryId);
            }
            else
            {
                await _toteAPI.EditWithoutImgAsync(request);
            }
            return RedirectToAction("Index");
        }

        public async Task<int> Delete(int Id)
        {
            return await _toteAPI.DeleteAsync(Id);
        }

        public async Task<IActionResult> DetailProduct(int Id)
        {
            _viewData.Tote = await _toteAPI.GetById(Id);
			_viewData.Categories = await _categoryAPI.GetAll();
			return View(_viewData);
        }
    }
}
