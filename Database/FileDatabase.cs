using ChimeWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Database
{
	public class FileDatabase(DbContextOptions<FileDatabase> options) : DbContext(options)
	{
		public DbSet<ProductImage> ProductImages { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var fileData = modelBuilder.Entity<FileData>();
			fileData.HasKey(e => e.Id);
			fileData.Property(e => e.OwnerId)
				.IsRequired(false);

			base.OnModelCreating(modelBuilder);
		}
	}
}
