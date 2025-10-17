using System.ComponentModel.DataAnnotations;

namespace ChimeWebApi.Models.Request
{
	public class ProductVariantDto
	{
		[Required(ErrorMessage = "Product id is required")]
		public Guid ProductId { get; set; }
		[Required(ErrorMessage = "Variant name array is required")]
		public string Name { get; set; } = string.Empty;
		[Required(ErrorMessage = "Price is required")]
		public decimal Price { get; set; }
		public decimal SalePrice { get; set; }
		public int Stock { get; set; }
		public DateTime SaleStart { get; set; }
		public DateTime SaleEnd { get; set; }
	}
}
