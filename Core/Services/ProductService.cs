using ChimeWebApi.Database;
using ChimeWebApi.Entities;
using ChimeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Core.Services
{
	public class ProductService(ChimeDatabase _Db) : IProductService
	{

		public async Task<bool> UploadProduct(ProductDto dto)
		{
			var appUser = await _Db.AppUsers.FindAsync(dto.AppUserId);
			if (appUser == null) return false;

			await _Db.Products.AddAsync(new()
			{
				AppUser = appUser,
				AppUserId = appUser.Id,
				Id = Guid.NewGuid(),
				ProductTypeId = dto.ProductTypeId,
				Description = dto.Description,
				Name = dto.Name,
				Price = dto.Price,
				SalePrice = dto.SalePrice
			});
			await _Db.SaveChangesAsync();

			return false;
		}

		public async Task<Product[]> GetProducts(RetrieveListDto dto)
		{
			return await _Db.Products
				.Skip(dto.Start)
				.Take(dto.End)
				.ToArrayAsync();
		}

		public Task<bool> ModifyProduct(ProductDto dto)
		{
			throw new NotImplementedException();
		}

		public Task<bool> RemoveProduct(ProductDto dto)
		{
			throw new NotImplementedException();
		}

		public async Task<ProductTypeDto[]> GetProductTypes()
		{
			var res = _Db.ProductTypes.Select(e => new ProductTypeDto
			{
				Id = e.Id,
				Name = e.Name
			});

			return await res.ToArrayAsync();
		}

		public async Task<Product?> GetProduct(ProductDto dto)
		{
			return null;
		}
	}
}
