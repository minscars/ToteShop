using MinsCarsShop.Data.Models;
using MinsCarsShop.Dto.Constants;
using MinsCarsShop.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Application.Interfaces
{
    public interface IOrderService
    {
        public Task<ApiResult<int>> OrderAsync();
    }
}
