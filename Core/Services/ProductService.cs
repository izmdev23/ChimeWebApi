using ChimeWebApi.Core.Enums;
using ChimeWebApi.Core.Objects;
using ChimeWebApi.Database;
using ChimeWebApi.Entities;
using ChimeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Core.Services
{
	public class ProductService(ProductDatabase _ProductDb, FileService _FileService)
	{
		
		public async Task<Response<bool>> UploadProduct(ProductUploadDto dto)
		{
			var prod = await _UploadProductData(new Product
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
			if (prod == null)
			{
				Console.WriteLine($"Error: Failed to upload data for {dto.Name} product.");
				return new Response<bool>()
				{
					Code = ResponseCode.Failed,
					Message = $"Error: Failed to upload data for {dto.Name} product.",
					Source = nameof(ProductService)
				};
			}

			foreach(IFormFile file in dto.Images)
			{
				string? filename = await _FileService.AddProductImage(file, prod.Id);
				if (filename == null)
				{
					Console.WriteLine($"Error: Failed to upload image for {dto.Name}.");
					continue;
				}
			}

			return new Response<bool>()
			{
				Code = ResponseCode.Success,
				Data = true,
				Message = $"Product {prod.Id} upload success",
				Source = nameof(ProductService)
			};
		}

		public Response GetProductTypes()
		{
			var data = _ProductDb.ProductTypes.OrderBy(e => e.Name).Select(e => new { e.Id, e.Name }).ToArray();
			return new Response
			{
				Code = ResponseCode.Success,
				Message = "Product types fetched and sorted in ascending order",
				Source = nameof(ProductService),
				Data = data
			};
		}


		private async Task<Product?> _UploadProductData(Product product)
		{
			var prod = await _ProductDb.Products.AddAsync(product);
			return prod.Entity;
		}

	}
}
