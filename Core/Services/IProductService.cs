using ChimeWebApi.Entities;
using ChimeWebApi.Models;

namespace ChimeWebApi.Core.Services
{
	public interface IProductService
	{
		public Task<bool> UploadProduct(ProductDto dto);
		public Task<bool> RemoveProduct(ProductDto dto);
		public Task<bool> ModifyProduct(ProductDto dto);
		public Task<Product[]> GetProducts(RetrieveListDto dto);
		public Task<ProductTypeDto[]> GetProductTypes();
		public Task<Product?> GetProduct(ProductDto dto);
	}
}
