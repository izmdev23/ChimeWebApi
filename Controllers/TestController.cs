using ChimeWebApi.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChimeWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{

		[Authorize]
		[HttpGet(nameof(TestAuthorized))]
		public IActionResult TestAuthorized()
		{
			return Ok("You are authorized");
		}

		[Authorize(Roles = AppRole.StoreManager)]
		[HttpGet(nameof(TestAdminOnlyEndpoint))]
		public IActionResult TestAdminOnlyEndpoint()
		{
			return Ok("You are an admin");
		}
	}
}
