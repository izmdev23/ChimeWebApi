using System.ComponentModel.DataAnnotations;

namespace ChimeWebApi.Entities
{
	public class User
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string MiddleName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public string Role { get; set; } = string.Empty;
		public string RefreshToken { get; set; } = string.Empty;
		public DateTime RefreshTokenExpireDate { get; set; } = DateTime.UtcNow;

		public ICollection<Product> Products { get; set; } = [];
	}
}
