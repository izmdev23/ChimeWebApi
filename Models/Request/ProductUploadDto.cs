namespace ChimeWebApi.Models.Request
{
	public class ProductUploadDto
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int ProductTypeId { get; set; } = -1;
		public Guid UploaderId { get; set; } = Guid.Empty;
		public Guid StoreId { get; set; } = Guid.Empty;
		public ProductVariantDto[] Variants = [];
	}
}
