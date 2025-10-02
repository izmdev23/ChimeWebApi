namespace ChimeWebApi.Models
{
	public class ProductListFetcherDataDto
	{
		public Guid UserId { get; set; }
		public int CategoryId { get; set; }
		public int Start { get; set; }
		public int End { get; set; }
	}
}
