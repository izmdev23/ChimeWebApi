using ChimeWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Database
{
	public class IdentityDatabase(DbContextOptions<IdentityDatabase> options) : DbContext(options)
	{
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var appUser = modelBuilder.Entity<User>();
			appUser.HasKey(e => e.Id);
			appUser.HasIndex(e => e.UserName).IsUnique();

			base.OnModelCreating(modelBuilder);
		}
	}
}
