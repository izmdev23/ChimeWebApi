namespace ChimeWebApi.Models
{
	public class ProductUploadDto
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; } = -1;
		public int ProductTypeId { get; set; } = -1;
		public Guid UploaderId { get; set; } = Guid.Empty;
		public decimal SalePrice { get; set; } = -1;
		public required IFormFile[] Images;
	}
}
