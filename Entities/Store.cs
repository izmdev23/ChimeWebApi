namespace ChimeWebApi.Entities
{
	public class Store
	{
		public Guid Id { get; set; }
		public Guid OwnerId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}
