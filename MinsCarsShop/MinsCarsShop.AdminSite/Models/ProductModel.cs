using MinsCarsShop.Dto.Category;
using MinsCarsShop.Dto.Tote;

namespace MinsCarsShop.AdminSite.Models
{
    public class ProductModel
    {
        public List<CategoryDTO> Categories { get; set; }
        public List<ToteDTO> Totes { get; set; }
        public ToteDTO Tote { get; set; }
    }
}
