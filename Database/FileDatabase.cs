using ChimeWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Database
{
	public class FileDatabase(DbContextOptions<FileDatabase> options) : DbContext(options)
	{
		public DbSet<ProductImage> Images { get; set; }
	}
}
