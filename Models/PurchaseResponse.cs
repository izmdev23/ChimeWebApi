using ChimeWebApi.Entities;

namespace ChimeWebApi.Models
{
	public class PurchaseResponse()
	{
		public required Guid TransactionId { get; set; }
		public required CartItem[] SuccessfulPurchase { get; set; }
		public required CartItem[] FailedPurchase { get; set; }
	}
}
