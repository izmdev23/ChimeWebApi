namespace ChimeWebApi.Models
{
	public class AuthResponseDto
	{
		public Guid UserId { get; set; }
		public string AccessToken { get; set; } = string.Empty;
		public string RefreshToken { get; set; } = string.Empty;
	}
}
