using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MinsCarsShop.Application.Interfaces;
using MinsCarsShop.Data.EF;
using MinsCarsShop.Data.Models;
using MinsCarsShop.Dto.Tote;
using System;
using Utilities.Constants;

namespace MinsCarsShop.Application.Services
{
    public class ToteService : IToteService
    {
        private readonly ToteDbContext _context;
		private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ToteService(ToteDbContext context, IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
			_context = context;
			_fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<ToteDTO>> GetAllAsync()
        {
            var result = await _context.Totes.Where(t => t.IsDeleted == false).Select(t => new ToteDTO()
            {
                Id = t.Id,
                Name = t.Name,
                Price = t.Price,
                Image = t.Image,
                CategoryId = t.Category.Id,
				CreatedTime = t.CreatedTime,
				UpdatedTime = t.UpdatedTime,
            }).ToListAsync();
            return result;	
        }

        public async Task<List<ToteDTO>> GetByCategoryIdAsync(int CategoryId)
        {
			var category = await _context.Categories.Where(category => category.Id == CategoryId).FirstOrDefaultAsync();
			if (category == null)
			{
				return null;
			}

			var result = await _context.Totes.Where(tote => tote.CategoryId == CategoryId).Select(tote => new ToteDTO()
										{
											Id = tote.Id,
											Name = tote.Name,
											Price = tote.Price,
											Image = tote.Image,
											CategoryId = tote.CategoryId
										}).ToListAsync();
            return result;
		}

		public async Task<ToteDTO> GetByIdAsync(int toteId)
		{
			var result = await _context.Totes.Include(c => c.Category)
				.Where(t => t.IsDeleted==false && t.Id == toteId)
				.Select(tote => new ToteDTO(){
												Id = tote.Id,
												Name = tote.Name,
												Price = tote.Price,
												Image = tote.Image,
												CategoryId = tote.CategoryId,
												CreatedTime = tote.CreatedTime,
												UpdatedTime = tote.UpdatedTime,
												CategoryName = tote.Category.Name
											}).FirstOrDefaultAsync();
			return result;
		}

		public async Task<List<ToteDTO>> FindByKeyAsync(string key)
		{
			if (key == null)
			{
				return null;
			}
			var result = await _context.Totes.Where(tote => tote.Name.Contains(key)).Select(t => new ToteDTO()
			{
				Id = t.Id,
				Name = t.Name,
				Price = t.Price,
				Image = t.Image,
				CategoryId = t.Category.Id
			}).ToListAsync();
			return result;
		}

        public async Task<int> CreateAsync(CreateToteDTO request)
		{
			var imageName = await _fileService.UploadFileAsync(request.Image, SystemConstant.IMG_TOTES_FOLDER);

			var tote = new Tote()
			{
				Name = request.Name,
				Price = request.Price,
				Image = imageName,
				CategoryId = request.CategoryId,
				CreatedTime = DateTime.Now
			};
			await _context.Totes.AddAsync(tote);
			var result = await _context.SaveChangesAsync();

			return result;
		}
		  
		public async Task<int> EditAsync(EditToteDTO request)
		{
			var tote = await _context.Totes.Where(t => t.Id == request.Id).FirstOrDefaultAsync();
			tote.Name = request.Name;
			tote.Price = request.Price;

            if (request.Image != null)
			{
				string path = Path.Combine(_webHostEnvironment.WebRootPath, SystemConstant.IMG_TOTES_FOLDER, tote.Image);
				await _fileService.RemoveFileAsync(path);
				var imageName = await _fileService.UploadFileAsync(request.Image, SystemConstant.IMG_TOTES_FOLDER);
				tote.Image = imageName;
			}
			tote.CategoryId = request.CategoryId;
			tote.UpdatedTime = DateTime.Now;

			var result = await _context.SaveChangesAsync();

            return result;
		}

        public async Task<int> EditWithoutImgAsync(EditToteDTO request)
		{
            var tote = await _context.Totes.Where(t => t.Id == request.Id).FirstOrDefaultAsync();
            tote.Name = request.Name;
            tote.Price = request.Price;
            tote.CategoryId = request.CategoryId;
            tote.UpdatedTime = DateTime.Now;

            var result = await _context.SaveChangesAsync();

            return result;
        }
        public async Task<int> DeleteAsync(int Id)
		{
			var tote = await _context.Totes.Where(t => t.Id == Id).FirstOrDefaultAsync();
			tote.IsDeleted = true;
			tote.UpdatedTime = DateTime.Now;
			var result = await _context.SaveChangesAsync();
			return result;
        }
    }
}
