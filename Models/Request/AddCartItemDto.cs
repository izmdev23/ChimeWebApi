namespace ChimeWebApi.Models.Request
{
	public class AddCartItemDto
	{
		public Guid ProductId { get; set; }
		public Guid VariantId { get; set; }
		public Guid UserId { get; set; }
		public int Quantity { get; set; }
	}
}
