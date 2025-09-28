using ChimeWebApi.Database;
using ChimeWebApi.Entities;
using ChimeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Core.Services
{
	public class ProductService(IdentityDatabase _Db, ProductDatabase _ProductDb, FileService _FileService)
	{
		
		public void UploadProduct(ProductUploadDto dto)
		{
			var prod = _UploadProductData(new Product
			{
				UploaderId = dto.UploaderId,
				Description = dto.Description,
				Name = dto.Name,
				Price = dto.Price,
				ProductTypeId = dto.ProductTypeId,
				Rating = 0,
				SalePrice = dto.SalePrice,
				StoreId = Guid.Empty
			});
		}


		private async Task<Product> _UploadProductData(Product product)
		{
			var prod = await _ProductDb.Products.AddAsync(product);
			return prod.Entity;
		}

		private void _UploadProductImage(IFormFile image)
		{

		}

	}
}
