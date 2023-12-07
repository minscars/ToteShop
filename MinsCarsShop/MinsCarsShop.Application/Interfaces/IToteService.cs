using MinsCarsShop.Data.Models;
using MinsCarsShop.Dto.Tote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Application.Interfaces
{
    public interface IToteService
    {
        public Task<List<ToteDTO>> GetAllAsync();
        public Task<List<ToteDTO>> GetByCategoryIdAsync(int CategoryId);
		public Task<ToteDTO> GetByIdAsync(int toteId);
		public Task<List<ToteDTO>> FindByKeyAsync(string key);
        public Task<int> CreateAsync(CreateToteDTO request);
        public Task<int> EditAsync(EditToteDTO request);
        public Task<int> EditWithoutImgAsync(EditToteDTO request);
        public Task<int> DeleteAsync(int Id);
    }
}
