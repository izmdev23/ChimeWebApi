namespace ChimeWebApi.Entities
{
	public class CartItem
	{
		public Guid Id { get; set; }
		public Guid VariantId { get; set; }
		public Guid UserId { get; set; }
		public DateTime DateAdded { get; set; }
		public int Quantity { get; set; }

		public Guid ProductId { get; set; }

		public Product Product { get; set; } = null!;

		public virtual ICollection<Transaction> Transactions { get; set; } = [];
	}
}