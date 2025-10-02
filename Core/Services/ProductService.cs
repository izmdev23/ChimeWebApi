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
				CategoryId = dto.ProductTypeId,
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

		/// <summary>
		/// Retrieves a list of products from database.<br/>
		/// <br/>
		/// <b>NOTE: </b>To be implented <br/>
		/// <list type="bullet">
		///		<item>The list will be curated based on user activity</item>
		/// </list>
		/// </summary>
		/// <param name="userId">The id of the user</param>
		/// <param name="categoryId">The id of the category. Useful if you want to filter items</param>
		/// <param name="start">The beginning index where to start extracting products. Pass -1 to not filter</param>
		/// <param name="count">How many products will be extracted from the curated list</param>
		/// <returns></returns>
		public async Task<Response<ProductDto[]>> GetProducts(Guid? userId, int categoryId, int start, int count)
		{
			ProductDto[] products = [];

			if (categoryId < 0)
			{
				products = await _ProductDb.Products
					.Select(e => new ProductDto
					{
						Id = e.Id,
						StoreId = e.StoreId,
						UploaderId = e.UploaderId,
						Name = e.Name,
						Description = e.Description,
						Price = e.Price,
						SalePrice = e.SalePrice,
						Rating = e.Rating,
						SaleStart = e.SaleStart,
						SaleEnd = e.SaleEnd,
						CategoryId = e.CategoryId
					})
					.Skip(start)
					.Take(count)
					.ToArrayAsync();
				return new Response<ProductDto[]>
				{
					Code = ResponseCode.Success,
					Message = $"Products fetched successfully",
					Source = nameof(ProductService),
					Data = products
				};
			}

			// TODO: insert product curator here

			products = await _ProductDb.Products
				.Where(e => e.CategoryId == categoryId)
				.Select(e => new ProductDto
				{
					Id = e.Id,
					StoreId = e.StoreId,
					UploaderId = e.UploaderId,
					Name = e.Name,
					Description = e.Description,
					Price = e.Price,
					SalePrice = e.SalePrice,
					Rating = e.Rating,
					SaleStart = e.SaleStart,
					SaleEnd = e.SaleEnd,
					CategoryId = e.CategoryId
				}).ToArrayAsync();
			return new Response<ProductDto[]>
			{
				Code = ResponseCode.Success,
				Message = $"Products fetched successfully",
				Source = nameof(ProductService),
				Data = products
			};
		}

		public async Task<Response<Product>> GetProduct(Guid id)
		{
			var data = await _ProductDb.Products.FindAsync(id);
			if(data == null)
			{
				return new Response<Product>
				{
					Code = ResponseCode.Failed,
					Message = $"Product id {id} is non-existent",
					Source = nameof(ProductService)
				};
			}
			return new Response<Product>
			{
				Code = ResponseCode.Success,
				Message = $"Products fetched successfully",
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
