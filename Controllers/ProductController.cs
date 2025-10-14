using ChimeWebApi.Core.Enums;
using ChimeWebApi.Core.Objects;
using ChimeWebApi.Core.Services;
using ChimeWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ChimeWebApi.Controllers
{
	[Route($"api/product")]
	[ApiController]
	public class ProductController(ProductService ProductService, FileService _FileService) : ControllerBase
	{
		[HttpPost]
		[Route("upload/image")]
		[Authorize(Roles = $"{AppRole.StoreManager},{AppRole.User}")]
		public async Task<IActionResult> UploadProductImage([FromForm] ImageVariantDto dto)
		{
			var res = await _FileService.AddProductVariantImage(dto);
			if (res.Code != ResponseCode.Success)
			{
				return BadRequest(new ApiResponse
				{
					Code = res.Code,
					Message = "Failed to upload image because " + res.Message
				});
			}
			return Ok(new ApiResponse
			{
				Code = res.Code,
				Message = res.Message,
				Data = res.Data
			});
		}

		[HttpGet]
		[Route("{productId},{variantId}/image")]
		public async Task<IActionResult> GetProductVariantsImageUrls(Guid productId, Guid variantId)
		{
			var result = await ProductService.GetVariantImages(productId, variantId);
			if (result.Code == ResponseCode.Failed)
			{
				return BadRequest(new ApiResponse(result.Code, result.Message));
			}

			return Ok(new ApiResponse(result.Code, result.Message, result.Data));
		}

		[HttpGet]
		[Route("{userId},{catId},{start},{end}")]
		public async Task<IActionResult> FetchProducts(Guid? userId, int catId, int start, int end)
		{
			var res = await ProductService.GetProducts(userId, catId, start, end);
			return Ok(new ApiResponse(res.Code, res.Message, res.Data));
		}

		[HttpGet]
		[Route("{prodId}")]
		public async Task<IActionResult> GetProduct(Guid prodId)
		{
			var res = await ProductService.GetProduct(prodId);
			return Ok(new ApiResponse(res.Code, res.Message, res.Data));
		}

		[HttpGet]
		[Route("{prodId}/variants")]
		public async Task<IActionResult> GetVariants(Guid prodId)
		{
			var res = await ProductService.GetVariants(prodId);
			return Ok(new ApiResponse(res.Code, res.Message, res.Data));
		}

		[HttpGet]
		[Route("categories")]
		public IActionResult FetchCategories()
		{
			var res = ProductService.GetCategories();
			return Ok(new ApiResponse(res.Code, res.Message, res.Data));
		}

		[HttpPost]
		[Route("upload")]
		[Authorize(Roles = "User")]
		[EnableCors(CorsPolicy.AllowChimeWebapp)]
		public async Task<IActionResult> UploadProduct(ProductUploadDto dto)
		{
			var res = await ProductService.AddProduct(dto);
			if (res.Code != ResponseCode.Success)
			{
				BadRequest(new ApiResponse(res.Code, res.Message));
			}
			return Ok(new ApiResponse(res.Code, res.Message, res.Data));
		}

		[HttpPost]
		[Route("add-prod-variant")]
		[Authorize(Roles = "User")]
		[EnableCors(CorsPolicy.AllowChimeWebapp)]
		public async Task<IActionResult> AddProductVariant(ProductVariantDto dto)
		{
			var res = await ProductService.AddVariant(dto);
			if (res.Code != ResponseCode.Success)
			{
				BadRequest(new ApiResponse(res.Code, res.Message));
			}
			return Ok(new ApiResponse(res.Code, res.Message, res.Data));
		}

		[HttpPost]
		[Route("caritems/add")]
		[Authorize(Roles = "User")]
		[EnableCors(CorsPolicy.AllowChimeWebapp)]
		public async Task<IActionResult> AddCartItem(AddCartItemDto dto)
		{
			var res = await ProductService.AddCartItem(dto.ProductId, dto.VariantId, dto.UserId, dto.Quantity);
			if (res.Code != ResponseCode.Success)
			{
				BadRequest(new ApiResponse(res.Code, res.Message));
			}
			return Ok(new ApiResponse(res.Code, res.Message));
		}

		[HttpGet]
		[Route("cartitems/{userId}")]
		//[Authorize(Roles = "User")]
		//[EnableCors(CorsPolicy.AllowChimeWebapp)]
		public async Task<IActionResult> GetCartItems(Guid userId)
		{
			var res = await ProductService.GetCartItems(userId);
			if (res.Code != ResponseCode.Success)
			{
				BadRequest(new ApiResponse(res.Code, res.Message));
			}
			return Ok(new ApiResponse(res.Code, res.Message, res.Data));
		}

	}
}
