using ChimeWebApi.Core.Enums;
using ChimeWebApi.Core.Objects;
using ChimeWebApi.Database;
using ChimeWebApi.Entities;
using ChimeWebApi.Models;
using ChimeWebApi.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Core.Services
{
	public class ProductService(ProductDatabase ProductDb, FileDatabase FileDb, FileService FileService, AuthService Auth)
	{
		private static readonly string DefaultVariantName = "Standard";

		public async Task<Response<ProductVariant?>> AddDefaultVariant(Guid productId)
		{
			return await AddVariant(DefaultVariantName, productId, -1);
		}

		public async Task<Response<ProductVariant?>> AddVariant(string name, Guid productId, decimal price)
		{
			var product = await GetProduct(productId);
			if (product == null)
			{
				return new()
				{
					Code = ResponseCode.Failed,
					Message = "Product id does not exist. Cannot create variant",
					Source = nameof(ProductService)
				};
			}
			if (product.Data == null)
			{
				return new()
				{
					Code = ResponseCode.Failed,
					Message = "Product data is null. Cannot create variant",
					Source = nameof(ProductService)
				};
			}

			var variant = await ProductDb.Variants.AddAsync(new()
			{	
				Name = name,
				ProductId = product.Data.Id,
				Product = product.Data,
				Price = price
			});
			await ProductDb.SaveChangesAsync();
			if (variant == null)
			{
				return new()
				{
					Code = ResponseCode.Failed,
					Message = "Failed to create variant",
					Source = nameof(ProductService)
				};
			}
			return new()
			{
				Code = ResponseCode.Success,
				Message = "Variant is created",
				Source = nameof(ProductService),
				Data = variant.Entity
			};
		}

		public async Task<Response<Guid?>> AddVariant(ProductVariantDto dto)
		{
			bool failed = false;
			//if ((await AddDefaultVariant(dto.ProductId)).Code == ResponseCode.Failed) failed = true;
			var addResult = await AddVariant(dto.Name, dto.ProductId, dto.Price);
			if (addResult.Code == ResponseCode.Failed) failed = true;
			if (failed) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Failed to create variants",
				Source = nameof(ProductService),
				Data = null
			};
			if (addResult.Data == null) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Failed to create variants",
				Source = nameof(ProductService),
				Data = null
			};

			return new()
			{
				Code = ResponseCode.Success,
				Message = "Variants are created",
				Source = nameof(ProductService),
				Data = addResult.Data.Id
			};
		}


		public async Task<Response<Product>> AddProduct(ProductUploadDto dto)
		{
			var prod = await ProductDb.Products.AddAsync(new Product
			{
				UploaderId = dto.UploaderId,
				Description = dto.Description,
				Name = dto.Name,
				CategoryId = dto.ProductTypeId,
				StoreId = Guid.Empty,
			});
			await ProductDb.SaveChangesAsync();
			if (prod == null)
			{
				Console.WriteLine($"Error: Failed to upload data for {dto.Name} product.");
				return new Response<Product>()
				{
					Code = ResponseCode.Failed,
					Message = $"Error: Failed to upload data for {dto.Name} product.",
					Source = nameof(ProductService),
				};
			}

			return new Response<Product>()
			{
				Code = ResponseCode.Success,
				Data = prod.Entity,
				Message = $"Product {prod.Entity.Id} upload success",
				Source = nameof(ProductService)
			};
		}

		public Response GetCategories()
		{
			var data = ProductDb.ProductCategories.OrderBy(e => e.Name).Select(e => new { e.Id, e.Name }).ToArray();
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
				products = await ProductDb.Products
					.Select(e => new ProductDto
					{
						Id = e.Id,
						StoreId = e.StoreId,
						UploaderId = e.UploaderId,
						Name = e.Name,
						Description = e.Description,
						CategoryId = e.CategoryId,
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
			// product curator is an algorithm that filters products based on user activity

			products = await ProductDb.Products
				.Where(e => e.CategoryId == categoryId)
				.Select(e => new ProductDto
				{
					Id = e.Id,
					StoreId = e.StoreId,
					UploaderId = e.UploaderId,
					Name = e.Name,
					Description = e.Description,
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
			var data = await ProductDb.Products.FindAsync(id);
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

		public async Task<Response<ProductVariant[]>> GetVariants(Guid id)
		{
			var data = await ProductDb.Variants.Where(e => e.ProductId == id).ToArrayAsync();
			if (data == null)
			{
				return new Response<ProductVariant[]>
				{
					Code = ResponseCode.Failed,
					Message = $"Cannot get variant because product id {id} is non-existent",
					Source = nameof(ProductService)
				};
			}
			return new Response<ProductVariant[]>
			{
				Code = ResponseCode.Success,
				Message = $"Products fetched successfully",
				Source = nameof(ProductService),
				Data = data
			};
		}

		public async Task<Response<string[]>> GetVariantImages(Guid productId, Guid variantId)
		{
			ProductImage[] imageMetadataArray = await FileDb.ProductImages.
				Where(e => e.ProductId == productId && e.VariantId == variantId).ToArrayAsync();

			if (imageMetadataArray.Length == 0)
			{
				return new()
				{
					Code = ResponseCode.Failed,
					Message = "This variant has no images",
					Source = nameof(ProductService)
				};
			}

			List<string> imageUrls = [];
			foreach(ProductImage img in imageMetadataArray)
			{
				string? image = FileService.GetImageVariant(productId, variantId, img.Name);
				if (image == null) continue;
				imageUrls.Add(image);
			}

			return new()
			{
				Code = ResponseCode.Success,
				Message = "Successfully fetched image urls from product variant",
				Source = nameof(ProductService),
				Data = imageUrls.ToArray()
			};
		}

		public async Task<Response<bool>> AddCartItem(Guid productId, Guid variantId, Guid userId, int quantity)
		{
			Product? product = await ProductDb.Products.FindAsync(productId);
			var user = await Auth.GetUserInfo(userId);

			if (user.Code == ResponseCode.Failed) return new()
			{
				Code = ResponseCode.Failed,
				Message = "User id is non existent",
				Source = nameof(ProductService)
			};
			if (user.Data == null) return new()
			{
				Code = ResponseCode.Failed,
				Message = $"Invalid data for user {userId}",
				Source = nameof(ProductService)
			};

			if (product == null) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Product id is non existent",
				Source = nameof(ProductService)
			};

			await ProductDb.CartItems.AddAsync(new()
			{
				VariantId = variantId,
				ProductId = productId,
				UserId = userId,
				Quantity = quantity,
				DateAdded = DateTime.UtcNow
			});

			var exists = await ProductDb.CartItems.FindAsync(userId);

			await ProductDb.SaveChangesAsync();
			return new()
			{
				Code = ResponseCode.Success,
				Message = "Product is added as cart item",
				Source = nameof(ProductService)
			};
		}

		public async Task<Response<CartItemResponseDto[]>> GetCartItems(Guid userId)
		{
			var cartItems = await ProductDb.CartItems
				.Where(e => e.UserId == userId)
				//.OrderByDescending(e => e.DateAdded)
				.ToArrayAsync();

			if (cartItems == null) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Failed to get cart items",
				Source = nameof(ProductService)
			};

			List<CartItemResponseDto> responses = [];

			foreach(var item in cartItems)
			{
				var itemImages = await FileDb.ProductImages
					.Where(e => e.ProductId == item.ProductId && e.VariantId == item.VariantId)
					.ToArrayAsync();
				if (itemImages == null) continue;
				List<string> imgs = [];
				foreach(var itemImg in itemImages)
				{
					var img = FileService.GetImageVariant(item.ProductId, item.VariantId, itemImg.Name);
					if (img == null) continue;
					imgs.Add(img);
				}
				responses.Add(new()
				{
					DateAdded = item.DateAdded,
					Id = item.Id,
					Images = [..imgs],
					ProductId = item.ProductId,
					UserId = userId,
					VariantId = item.VariantId,
					Quantity = item.Quantity
				});
			}

			return new()
			{
				Code = ResponseCode.Success,
				Message = "Successfully retrieved cart items",
				Source = nameof(ProductService),
				Data = [..responses]
			};
		}


	}
}
