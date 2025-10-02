using System.ComponentModel.DataAnnotations;

namespace ChimeWebApi.Models
{
	public class ProductDto
	{
		public Guid Id { get; set; }
		public Guid StoreId { get; set; }
		public Guid UploaderId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal SalePrice { get; set; }
		public float Rating { get; set; }
		public DateTime SaleStart { get; set; }
		public DateTime SaleEnd { get; set; }
		public int CategoryId { get; set; }
		public int Stock { get; set; }
	}
}
