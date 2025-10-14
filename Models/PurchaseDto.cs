namespace ChimeWebApi.Models
{
	public class PurchaseDto
	{
		public required Guid[] CartItemIds { get; set; }
		public Guid UserId { get; set; }
	}
}
