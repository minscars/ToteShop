using Azure.Core;
using Microsoft.AspNetCore.Http;
using MinsCarsShop.Dto.Tote;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Integration
{
	public interface IToteAPI
	{
		[Get("/api/Totes")]
		public Task<List<ToteDTO>> GetAll();

		[Get("/api/Totes/Category/{CategoryId}")]
		public Task<List<ToteDTO>> GetByCategoryId(int CategoryId);

		[Get("/api/Totes/{ToteId}")]
		public Task<ToteDTO> GetById(int ToteId);

		[Get("/api/Totes/Search/{Key}")]
		public Task<List<ToteDTO>> FindByKey(string key);

		[Multipart]
		[Post("/api/Totes")]
		Task<int> CreateAsync([AliasAs("Image")] StreamPart image, [AliasAs("Name")] string name, [AliasAs("Price")] int price, [AliasAs("CategoryId")] int categoryId);

		[Multipart]
		[Patch("/api/Totes")]
		Task<int> EditAsync([AliasAs("Image")] StreamPart image, [AliasAs("Id")] int id, [AliasAs("Name")] string name, [AliasAs("Price")] int price, [AliasAs("CategoryId")] int categoryId);

		[Multipart]
		[Put("/api/Totes")]
		Task<int> EditWithoutImgAsync(EditToteDTO request);

		[Delete("/api/Totes/{Id}")]
		public Task<int> DeleteAsync(int Id);
    } 
}
