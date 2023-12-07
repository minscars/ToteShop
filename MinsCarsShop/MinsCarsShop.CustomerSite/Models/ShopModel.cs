using MinsCarsShop.Dto.Category;
using MinsCarsShop.Dto.Tote;

namespace MinsCarsShop.CustomerSite.Models
{
	public class ShopModel
	{
		public List<ToteDTO> Totes { get; set; }
		public List<CategoryDTO> Categories { get; set; }

		public ToteDTO Tote { get; set; }
	}
}
