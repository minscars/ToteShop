using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinsCarsShop.Application.Interfaces;
using MinsCarsShop.Application.Services;
using MinsCarsShop.Dto.Category;
using MinsCarsShop.Dto.Tote;

namespace MinsCarsShop.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

		private string setImageName(string currentName)
		{
			return String.Format("{0}://{1}{2}/images/Categories/{3}", Request.Scheme, Request.Host, Request.PathBase, currentName);
		}

		[HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
			result.ForEach(s => s.Image = setImageName(s.Image));
			return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromForm] CreateCateDTO request)
        {
            var result = await _categoryService.CreateAsync(request);
            return Ok(result);
        }
    }

    
}
