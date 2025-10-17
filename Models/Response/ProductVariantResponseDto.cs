namespace ChimeWebApi.Models.Response
{
	public class ProductVariantResponseDto
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal SalePrice { get; set; }
		public DateTime SaleStart { get; set; }
		public DateTime SaleEnd { get; set; }
		public float Rating { get; set; }
		public int Stock { get; set; }
	}
}
