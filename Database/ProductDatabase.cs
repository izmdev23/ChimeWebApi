using ChimeWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Database
{
	public class ProductDatabase(DbContextOptions<ProductDatabase> options) : DbContext(options)
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var product = modelBuilder.Entity<Product>();
			product.HasKey(e => e.Id);
			product.HasOne(e => e.ProductType).WithMany(e => e.Products);

			base.OnModelCreating(modelBuilder);
		}
	}
}
