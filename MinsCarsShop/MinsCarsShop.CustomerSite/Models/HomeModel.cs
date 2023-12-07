using MinsCarsShop.Dto.Category;
using MinsCarsShop.Dto.Tote;

namespace MinsCarsShop.CustomerSite.Models
{
	public class HomeModel
	{
		public List<ToteDTO> Totes { get; set; }

		public List<CategoryDTO> Categories { get; set; }

		public ToteDTO Tote { get; set; }

		public bool Carts { get; set; }
	}
}
