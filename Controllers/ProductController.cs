using ChimeWebApi.Core.Enums;
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
	public class ProductController(ProductService _ProductService) : ControllerBase
	{
		[HttpPost(nameof(GetProducts))]
		public async Task<IActionResult> GetProducts(RetrieveListDto dto)
		{
			var products = await _ProductService.GetProducts(dto);
			return Ok(products);
		}

		[HttpGet(nameof(GetProductTypes))]
		public async Task<IActionResult> GetProductTypes()
		{
			var res = await _ProductService.GetProductTypes();
			return Ok(res);
		}

		[EnableCors(CorsPolicy.AllowChimeWebapp)]
		[Authorize(Roles = "User")]
		[HttpPost(nameof(UploadProduct))]
		public async Task<IActionResult> UploadProduct(ProductDto dto)
		{
			bool res = await _ProductService.UploadProduct(dto);
			if (res == false) BadRequest("Failed to upload product");
			return Ok();
		}
	}
}
