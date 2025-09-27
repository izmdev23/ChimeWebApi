using ChimeWebApi.Core.Objects;
using ChimeWebApi.Entities;
using ChimeWebApi.Models;

namespace ChimeWebApi.Core.Services
{
	public interface IAuthService
	{
		public Task<AppUser?> Register(SignUpDto dto);
		public Task<AuthResponseDto?> Login(LoginDto dto);
		public Task<AuthResponseDto?> RenewRefreshToken(string authString);
		public Task<AppUser?> GetAppUserInfo(string authString);
	}
}
