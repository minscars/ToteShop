using Microsoft.EntityFrameworkCore;
using MinsCarsShop.Application.Interfaces;
using MinsCarsShop.Data.EF;
using MinsCarsShop.Data.Models;
using MinsCarsShop.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Constants;

namespace MinsCarsShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ToteDbContext _context;
        private readonly IFileService _fileService;

        public CategoryService(ToteDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            var result = await _context.Categories.Select(c => new CategoryDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image,
                CreatedTime = c.CreatedTime
            }).ToListAsync();
            return result;
        }

        public async Task<int> CreateAsync(CreateCateDTO request)
        {
            var imageName = await _fileService.UploadFileAsync(request.Image, SystemConstant.IMG_CATES_FOLDER);

            var cate = new Category()
            {
                Name = request.Name,
                Image = imageName,
                CreatedTime = DateTime.Now
            };
            await _context.Categories.AddAsync(cate);
            var result = await _context.SaveChangesAsync();

            return result;

        }
    }
}
