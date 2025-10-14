using ChimeWebApi.Core.Enums;
using ChimeWebApi.Core.Objects;
using ChimeWebApi.Core.Services;
using ChimeWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChimeWebApi.Controllers
{
	[Route("api/files")]
	[ApiController]
	public class FileController(FileService _FileService) : ControllerBase
	{
		[HttpPost]
		[Route("upload/product-image")]
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
	}
}
