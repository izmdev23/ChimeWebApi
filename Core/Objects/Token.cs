namespace ChimeWebApi.Core.Objects
{
	public record Token
	{
		public required string AccessToken { get; set; }
		public required string RefreshToken { get; set; }
	}
}
