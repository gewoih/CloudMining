using CloudMining.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CloudMining.Data
{
	internal class ApplicationContext : DbContext
	{
		public DbSet<Member> Members { get; set; }
		public DbSet<Deposit> Deposits { get; set; }
		public DbSet<Device> Devices { get; set; }
		public DbSet<Currency> Currencies { get; set; }
		public DbSet<Role> Roles { get; set; }

		public ApplicationContext()
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();

			Roles.Add(new Role { name = "Участник", fee = 0 });
			Roles.Add(new Role { name = "Администратор", fee = 3 });
			Roles.Add(new Role { name = "Менеджер", fee = 5 });
			SaveChanges();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
			optionsBuilder.EnableSensitiveDataLogging();
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CloudMiningDB;Trusted_Connection=True;");
		}
	}
}
