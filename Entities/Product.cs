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

		public int CategoryId { get; set; }

		public ProductCategory Category { get; set; } = null!;

		public virtual ICollection<ProductVariant> Variants { get; set; } = [];
		public virtual ICollection<CartItem> CartItems { get; set; } = [];
	}
}
