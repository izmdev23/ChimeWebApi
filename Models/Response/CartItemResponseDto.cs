using ChimeWebApi.Core.Objects;

namespace ChimeWebApi.Models.Response
{
	public class CartItemResponseDto
	{
		public required Guid Id { get; set; }
		public required Guid VariantId { get; set; }
		public required Guid UserId { get; set; }
		public required DateTime DateAdded { get; set; }
		public required Guid ProductId { get; set; }
		public required string[] Images { get; set; }
		public required int Quantity { get; set; }
	}
}
