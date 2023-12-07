using MinsCarsShop.Data.Models;
using MinsCarsShop.Dto.Category;
using MinsCarsShop.Dto.Tote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> GetAllAsync();
        public Task<int> CreateAsync(CreateCateDTO request);
    }
}
