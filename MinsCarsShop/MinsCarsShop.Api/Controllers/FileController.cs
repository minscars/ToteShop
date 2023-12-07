using Microsoft.AspNetCore.Mvc;
using MinsCarsShop.Application.Interfaces;

namespace MinsCarsShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadToteImageAsync([FromForm] IFormFile FileUploaded, string folderName)
        {
            var result = await _fileService.UploadFileAsync(FileUploaded, folderName);
            return Ok(result);
        }
    }
}