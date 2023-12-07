using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Integration
{
    public interface IOrderAPI
    {
        [Post("/api/Order/Order")]
        public Task<int> OrderAsync();
    }
}
