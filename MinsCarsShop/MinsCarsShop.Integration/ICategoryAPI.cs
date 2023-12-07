using MinsCarsShop.Dto.Category;
using MinsCarsShop.Dto.Tote;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Integration
{
	public interface ICategoryAPI
	{
		[Get("/api/Categories")]
		public Task<List<CategoryDTO>> GetAll();

        [Multipart]
        [Post("/api/Categories")]
        Task<int> CreateAsync([AliasAs("Image")] StreamPart image, [AliasAs("Name")] string name);

    }
}
