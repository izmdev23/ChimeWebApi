using ChimeWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Database
{
	public class ChimeDatabase(DbContextOptions<ChimeDatabase> options) : DbContext(options)
	{
		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var appUser = modelBuilder.Entity<AppUser>();
			appUser.HasKey(e => e.Id);
			appUser.HasIndex(e => e.UserName).IsUnique();

			var product = modelBuilder.Entity<Product>();
			product.HasKey(e => e.Id);
			product.HasOne(e => e.ProductType).WithMany(e => e.Products);
			product.HasOne(e => e.AppUser).WithMany(e => e.Products);

			base.OnModelCreating(modelBuilder);
		}
	}
}
