namespace ChimeWebApi.Entities
{
	public class ProductImage
	{
		public Guid Id { get; set; }
		public required Guid ProductId { get; set; }
		public required Guid VariantId { get; set; }
		public required string Name { get; set; }
	}
}