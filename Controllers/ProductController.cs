using ChimeWebApi.Core.Enums;
using ChimeWebApi.Core.Objects;
using ChimeWebApi.Core.Services;
using ChimeWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChimeWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController(ProductService _ProductService, FileService _FileService) : ControllerBase
	{
		//[HttpGet("{id}")]
		//public async Task<IActionResult> GetProduct(Guid id)
		//{
		//	var res = await _ProductService.GetProduct(id);
		//	if (res == null) return BadRequest();
		//	return Ok(new ProductDto()
		//	{
		//		AppUserId = res.AppUserId,
		//		Description = res.Description,
		//		Id = res.Id,
		//		Name = res.Name,
		//		Price = res.Price,
		//		ProductTypeId = res.ProductTypeId,
		//		SalePrice = res.SalePrice,
		//		ProductCategoryName = (await _ProductService.GetCategoryName(res.ProductTypeId)) ?? "Uncategorized"
		//	});
		//}

		//[HttpPost(nameof(GetProducts))]
		//public async Task<IActionResult> GetProducts(RetrieveListDto dto)
		//{
		//	var products = await _ProductService.GetProducts(dto);
		//	return Ok(products);
		//}

		[HttpGet(nameof(FetchCategories))]
		public IActionResult FetchCategories()
		{
			var res = _ProductService.GetProductTypes();
			return Ok(new ControllerResponse(res.Code, res.Message, res.Data));
		}

		[EnableCors(CorsPolicy.AllowChimeWebapp)]
		[Authorize(Roles = "User")]
		[HttpPost(nameof(UploadProduct))]
		public async Task<IActionResult> UploadProduct(ProductUploadDto dto)
		{
			var res = await _ProductService.UploadProduct(dto);
			if (res.Code != ResponseCode.Success)
			{
				BadRequest(new ControllerResponse(res.Code, res.Message));
			}
			return Ok(new ControllerResponse(res.Code, res.Message));
		}

		//[EnableCors(CorsPolicy.AllowChimeWebapp)]
		//[Authorize(Roles = "User")]
		//[HttpPost(nameof(UploadFile))]
		//public async Task<IActionResult> UploadFile(ProductUploadDto file)
		//{
		//	foreach(IFormFile img in file.Images)
		//	{
		//		var fileName = await _ProductService.UploadProduct(file);

		//	}

		//	//bool res = await _ProductService.(dto);
		//	//if (res == false) BadRequest("Failed to upload product");
		//	return Ok();
		//}
	}
}
