namespace ChimeWebApi.Models.Request
{
	public class UpdateCartItemQuantityRequestDto
	{
		public Guid CartItemId { get; set; }
		public int Quantity { get; set; }
	}
}
