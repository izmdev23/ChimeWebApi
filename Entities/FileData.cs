using ChimeWebApi.Core.Enums;

namespace ChimeWebApi.Entities
{
	public class FileData
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public FileOwnerType Owner { get; set; }
		public Guid? OwnerId { get; set; }
	}
}
