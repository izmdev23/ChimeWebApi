using ChimeWebApi.Core.Enums;
using ChimeWebApi.Core.Objects;
using ChimeWebApi.Core.Services;
using ChimeWebApi.Models;
using ChimeWebApi.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChimeWebApi.Controllers
{
	[Route("api/vendor")]
	[ApiController]
	public class VendorController(VendorService Vendor) : ControllerBase
	{
		[HttpPost]
		[Route("place-order")]
		public async Task<IActionResult> PlaceOrder([FromForm] PurchaseDto dto)
		{
			var response = await Vendor.ConfirmPurchase(dto);
			if (response.Code == ResponseCode.Failed)
			{
				return BadRequest(new ApiResponse
				{
					Code = response.Code,
					Message = response.Message
				});
			}

			return Ok(new ApiResponse
			{
				Code = response.Code,
				Message = response.Message,
				Data = response.Data,
			});
		}

		//[HttpPost]
		//[Route("quick-buy")]
		//public async Task<Response<CartItemResponseDto[]>> QuickBuy(Guid productId)
		//{

		//}
	}
}
