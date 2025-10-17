using ChimeWebApi.Core.Objects;
using ChimeWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Database
{
	public class ProductDatabase(DbContextOptions<ProductDatabase> options) : DbContext(options)
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ProductVariant> Variants { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Transaction> Transactions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var variant = modelBuilder.Entity<ProductVariant>();
			variant.HasKey(e => e.Id);
			variant.HasOne(e => e.Product)
				.WithMany(e => e.Variants)
				.HasForeignKey(e => e.ProductId);

			var cartItem = modelBuilder.Entity<CartItem>();
			cartItem.HasKey(e => e.Id);
			cartItem
				.HasOne(e => e.Product)
				.WithMany(e => e.CartItems)
				.HasForeignKey(e => e.ProductId);

			var transaction = modelBuilder.Entity<Transaction>();
			transaction
				.HasOne(e => e.CartItem)
				.WithMany(e => e.Transactions)
				.HasForeignKey(e => e.CartItemId);

			var category = modelBuilder.Entity<ProductCategory>();
			category.HasKey(e => e.Id);

			List<ProductCategory> cats = [];
			int i = 0;
			foreach(var cat in Categories.Values)
			{
				i++;
				cats.Add(new()
				{
					Id = i,
					Name = cat,
				});
			}

			category.HasData([..cats]);

			var product = modelBuilder.Entity<Product>();
			product.HasKey(e => e.Id);
			product.HasOne(e => e.Category)
				.WithMany(e => e.Products)
				.HasForeignKey(e => e.CategoryId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
