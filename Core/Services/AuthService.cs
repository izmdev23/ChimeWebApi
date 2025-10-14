using ChimeWebApi.Core.Enums;
using ChimeWebApi.Core.Objects;
using ChimeWebApi.Database;
using ChimeWebApi.Entities;
using ChimeWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ChimeWebApi.Core.Services
{
	public class AuthService(IdentityDatabase IdentityDb, IConfiguration _Configuration)
	{
		JsonWebTokenHandler jwtHandler = new();

		public JsonWebToken? ReadAuthString(string authString)
		{
			var finalAuthString = authString.Replace("Bearer ", string.Empty);
			if (jwtHandler.CanReadToken(finalAuthString) == false) return null;
			return jwtHandler.ReadJsonWebToken(finalAuthString);
		}

		public async Task<Response<AuthResponseDto>> Login(LoginDto dto)
		{
			User? user = await IdentityDb.Users.FirstOrDefaultAsync(e => e.UserName == dto.UserName);
			if (user == null) return new Response<AuthResponseDto>
			{
				Code = ResponseCode.Failed,
				Message = $"Incorrect login credentials",
				Source = nameof(AuthService)
			};

			if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, dto.Password)
				== PasswordVerificationResult.Failed) return new Response<AuthResponseDto>
				{
					Code = ResponseCode.Failed,
					Message = $"Incorrect login credentials",
					Source = nameof(AuthService)
				};

			var result = new AuthResponseDto()
			{
				UserId = user.Id,
				AccessToken = CreateToken(user),
				RefreshToken = CreateRefreshToken(),
			};

			return new Response<AuthResponseDto>
			{
				Code = ResponseCode.Success,
				Message = $"User authenticated",
				Source = nameof(AuthService),
				Data = result
			};
		}

		public async Task<Response<User>> Register(SignUpDto dto)
		{
			int accountExists = await IdentityDb.Users.Where(e => e.UserName == dto.UserName).CountAsync();
			if (accountExists > 0) return new Response<User>
			{
				Code = ResponseCode.Failed,
				Message = $"Username {dto.UserName} is already taken",
				Source = nameof(AuthService)
			};

			User user = new();
			var passwordHash = new PasswordHasher<User>().HashPassword(user, dto.Password);

			user.UserName = dto.UserName;
			user.PasswordHash = passwordHash;
			user.Role = AppRole.User;
			user.FirstName = dto.FirstName;
			user.MiddleName = dto.MiddleName;
			user.LastName = dto.LastName;

			await IdentityDb.Users.AddAsync(user);
			await IdentityDb.SaveChangesAsync();

			return new Response<User>
			{
				Code = ResponseCode.Success,
				Message = $"Account is created",
				Source = nameof(AuthService),
			};
		}

		public async Task<AuthResponseDto?> RenewRefreshToken(string authString)
		{
			var handler = new JsonWebTokenHandler();
			var finalAuthString = authString.Replace("Bearer ", string.Empty);
			if (handler.CanReadToken(finalAuthString) == false) return null;
			var token = handler.ReadJsonWebToken(finalAuthString);
			
			string userId = string.Empty;
			string userName = string.Empty;
			try
			{
				userId = token.GetClaim(ClaimTypes.NameIdentifier).Value;
				userName = token.GetClaim(ClaimTypes.Name).Value;
			}
			catch(System.ArgumentException e)
			{
				Console.WriteLine(e);
				return null;
			}

			Guid parsedUserId;
			if (Guid.TryParse(userId, out parsedUserId) == false) return null;

			var user = await IdentityDb.Users.FindAsync(parsedUserId);

			if (user == null) return null;
			if (user.UserName != userName) return null;

			user.RefreshToken = CreateRefreshToken();
			user.RefreshTokenExpireDate = DateTime.UtcNow.AddDays(7);
			await IdentityDb.SaveChangesAsync();

			return new AuthResponseDto()
			{
				UserId = user.Id,
				AccessToken = CreateToken(user),
				RefreshToken = CreateRefreshToken()
			};
		}


		public string CreateToken(User user)
		{
			var claims = new Dictionary<string, object>
			{
				[ClaimTypes.Name] = user.UserName,
				[ClaimTypes.NameIdentifier] = user.Id,
				[ClaimTypes.Role] = user.Role
			};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:Key"]!));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

			var tokenDescription = new SecurityTokenDescriptor
			{
				Issuer = _Configuration.GetValue<string>("JWT:Issuer"),
				Audience = _Configuration.GetValue<string>("JWT:Audience"),
				NotBefore = DateTime.UtcNow,
				Expires = DateTime.UtcNow.AddDays(1),
				SigningCredentials = credentials,
				Claims = claims,
			};

			return new JsonWebTokenHandler().CreateToken(tokenDescription);
		}

		public string CreateRefreshToken()
		{
			var tokenBytes = new byte[64];
			var rng = RandomNumberGenerator.Create();
			rng.GetBytes(tokenBytes);
			return Convert.ToBase64String(tokenBytes);
		}

		public async Task<Response<User>> GetAppUserInfo(string authString)
		{
			var token = ReadAuthString(authString);
			if (token == null) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Invalid user token",
				Source = nameof(AuthService)
			};
			var appUserId = token.GetClaim(ClaimTypes.NameIdentifier);
			if (appUserId == null) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Failed to validate user claim",
				Source = nameof(AuthService)
			};
			Guid userId;
			if (Guid.TryParse(appUserId.Value, out userId) == false) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Invalid user id",
				Source = nameof(AuthService)
			};
			var appUser = await IdentityDb.Users.FindAsync(userId);

			return new Response<User>
			{
				Code = ResponseCode.Success,
				Message = "User info retrieved",
				Source = nameof(AuthService),
				Data = appUser
			};
		}

		public async Task<Response<User>> GetUserInfo(Guid userId)
		{
			User? user = await IdentityDb.Users.FindAsync(userId);
			if (user == null) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Failed to find user",
				Source = nameof(AuthService)
			};
			return new()
			{
				Code = ResponseCode.Success,
				Message = "Found user",
				Source = nameof(AuthService),
				Data = user
			};
		}
	}
}
