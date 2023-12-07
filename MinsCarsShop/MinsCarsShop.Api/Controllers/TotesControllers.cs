using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinsCarsShop.Application.Interfaces;
using MinsCarsShop.Application.Services;
using MinsCarsShop.Dto.Tote;

namespace MinsCarsShop.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class TotesController : ControllerBase
   {
       private IToteService _toteService;

       public TotesController(IToteService toteService)
       {
          _toteService = toteService;
       }

		private string setImageName(string currentName)
		{
			return String.Format("{0}://{1}{2}/images/Totes/{3}", Request.Scheme, Request.Host, Request.PathBase, currentName);
		}

	    [HttpGet]
       [AllowAnonymous]
       public async Task<IActionResult> GetAll()
       {
            var result = await _toteService.GetAllAsync();
		    result.ForEach(s => s.Image = setImageName(s.Image));
	        return Ok(result);
       }

		[HttpGet("Category/{CategoryId}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetByCategoryId([FromRoute] int CategoryId)
		{
			var result = await _toteService.GetByCategoryIdAsync(CategoryId);
			result.ForEach(s => s.Image = setImageName(s.Image));
			if (result == null)
			{
				return NotFound($"Can not find product with id {CategoryId}");
			}
			return Ok(result);
		}

		[HttpGet("{ToteId}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetById([FromRoute] int ToteId)
		{
			var result = await _toteService.GetByIdAsync(ToteId);
			result.Image = setImageName(result.Image);
			if (result == null)
			{
				return NotFound($"Can not find product with id {ToteId}");
			}
			return Ok(result);
		}


		[HttpGet("Search/{Key}")]
		[AllowAnonymous]
		public async Task<IActionResult> FindByKey([FromRoute] string Key)
		{
			var totes = await _toteService.FindByKeyAsync(Key);
			totes.ForEach(c => c.Image = setImageName(c.Image));
			if (totes == null)
			{
				return NotFound($"Can not find vegetables with Key {Key}");
			}
			return Ok(totes);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Create([FromForm] CreateToteDTO request)
		{
			var result = await _toteService.CreateAsync(request);
			return Ok(result);
		}

        [HttpPatch]
        [AllowAnonymous]
        public async Task<IActionResult> Edit([FromForm] EditToteDTO request)
        {
            var result = await _toteService.EditAsync(request);
            return Ok(result);
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> EditWithoutImg([FromForm] EditToteDTO request)
        {
            var result = await _toteService.EditWithoutImgAsync(request);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        [AllowAnonymous]
		public async Task<IActionResult> Delete([FromRoute] int Id)
		{
			var result = await _toteService.DeleteAsync(Id);
			return Ok(result);
		}

    }
}
