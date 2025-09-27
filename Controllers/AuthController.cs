using ChimeWebApi.Core.Objects;
using ChimeWebApi.Core.Services;
using ChimeWebApi.Entities;
using ChimeWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ChimeWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController(AuthService _AuthService) : ControllerBase
	{
		private static AppUser user = new();

		[HttpPost(nameof(Register))]
		public async Task<IActionResult> Register(SignUpDto dto)
		{
			var user = await _AuthService.Register(dto);
			if (user == null) return BadRequest("Failed to create account");
			return Created(nameof(Register), user);
		}

		[HttpPost(nameof(Login))]
		public async Task<IActionResult> Login(LoginDto dto)
		{
			var token = await _AuthService.Login(dto);
			if (token == null) return Unauthorized("Incorrect login credentials");
			return Ok(token);
		}

		[HttpPost(nameof(RenewRefreshToken))]
		public async Task<IActionResult> RenewRefreshToken()
		{
			var authString = Request.Headers.Authorization;
			if (authString.Count == 0) return Unauthorized();
			var token = await _AuthService.RenewRefreshToken(authString!);
			if (token == null) return BadRequest("Failed to renew refresh token");
			return Ok(token);
		}

		[HttpGet(nameof(GetAppUserInfo))]
		public async Task<IActionResult> GetAppUserInfo()
		{
			var authString = Request.Headers.Authorization;
			if (authString.Count == 0) return Unauthorized();
			var appData = await _AuthService.GetAppUserInfo(authString!);
			if (appData == null) return Unauthorized("Failed to fetch user info");
			AccountDto dto = new()
			{
				Role = appData.Role,
				UserName = appData.UserName
			};
			return Ok(dto);
		}


	}
}
