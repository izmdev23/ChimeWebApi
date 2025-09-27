using System.ComponentModel.DataAnnotations;

namespace ChimeWebApi.Models
{
	public class ProductDto
	{
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public string Description { get; set; } = string.Empty;
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int ProductTypeId { get; set; }
		[Required]
		public Guid AppUserId { get; set; }

		public decimal SalePrice { get; set; }
	}
}
