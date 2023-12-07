using Microsoft.AspNetCore.Http;
using MinsCarsShop.Dto.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Dto.Tote
{
    public class CreateToteDTO
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
