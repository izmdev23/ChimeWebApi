using ChimeWebApi.Core.Enums;
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
	[Route("api/auth")]
	[ApiController]
	public class AuthController(AuthService _AuthService) : ControllerBase
	{

		[HttpPost]
		[Route("signup")]
		public async Task<IActionResult> Signup(SignUpDto dto)
		{
			var user = await _AuthService.Register(dto);
			if (user.Code == ResponseCode.Failed)
				return BadRequest(new ApiResponse(user.Code, user.Message, user.Data));
			return Created(nameof(Signup), new ApiResponse(user.Code, user.Message, user.Data));
		}

		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login(LoginDto dto)
		{
			var result = await _AuthService.Login(dto);
			if (result.Code == ResponseCode.Failed)
				return Unauthorized(new ApiResponse(result.Code, result.Message, result.Data));
			return Ok(new ApiResponse(result.Code, result.Message, result.Data));
		}

		[HttpPost]
		[Route("renew-refrehs-token")]
		public async Task<IActionResult> RenewRefreshToken()
		{
			var authString = Request.Headers.Authorization;
			if (authString.Count == 0) return Unauthorized();
			var token = await _AuthService.RenewRefreshToken(authString!);
			if (token == null) return BadRequest("Failed to renew refresh token");
			return Ok(token);
		}

		[HttpGet]
		[Route("get-user")]
		public async Task<IActionResult> GetUser()
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
