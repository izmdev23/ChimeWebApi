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

			appUser.HasData(
				new User
				{
					Id = Guid.NewGuid(),
					FirstName = "Anton Jay",
					MiddleName = "Adlit",
					LastName = "Cañete",
					PasswordHash = "AQAAAAIAAYagAAAAEMCAqFd1gUqBRssags1TTRQ82pY9RdgqkwFXMMveYGDymbbWjUBA5RoRZZKBQfm1tw==",
					Role = "User",
					UserName = "antonjay23"
				},
				new User
				{
					Id = Guid.NewGuid(),
					FirstName = "Angel",
					MiddleName = "Caballes",
					LastName = "Pacaña",
					PasswordHash = "AQAAAAIAAYagAAAAEDOJTHYMo3ZEGpRlyY/ygV8n2gv1zd0sALftHy+bnM9pZe5cdXOwZtijzcLZRZpw8Q==",
					Role = "User",
					UserName = "angel26"
				});

			base.OnModelCreating(modelBuilder);
		}
	}
}
