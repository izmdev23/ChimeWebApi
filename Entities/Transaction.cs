using ChimeWebApi.Core.Enums;

namespace ChimeWebApi.Entities
{
	public class Transaction
	{
		public Guid Id { get; set; }
		public Guid CartItemId { get; set; }
		public TransactionStatus Status { get; set; }
		public required DateTime CreatedDate { get; set; }
		public required DateTime ResolvedDate { get; set; }

		public required CartItem CartItem { get; set; }
	}
}
