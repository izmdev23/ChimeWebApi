using System.ComponentModel.DataAnnotations;

namespace ChimeWebApi.Models
{
	public class LoginDto
	{
		[Required(ErrorMessage = $"{nameof(UserName)} is required")]
		public string UserName { get; set; } = string.Empty;
		[Required(ErrorMessage = $"{nameof(Password)} is required")]
		public string Password { get; set; } = string.Empty;
	}
}
