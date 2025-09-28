using System.ComponentModel.DataAnnotations;

namespace ChimeWebApi.Entities
{
	public class Product
	{
		public Guid Id { get; set; }
		public Guid StoreId { get; set; }
		public Guid UploaderId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal SalePrice { get; set; }
		public int ProductTypeId { get; set; }
		public float Rating { get; set; }

		public ProductType ProductType { get; set; } = null!;
	}
}
