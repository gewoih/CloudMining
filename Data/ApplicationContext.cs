using CloudMining.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudMining.Data
{
	internal class ApplicationContext : DbContext
	{
		public DbSet<Member> Members { get; set; }
		public DbSet<Deposit> Deposits { get; set; }
		public DbSet<Device> Devices { get; set; }
		public DbSet<Currency> Currencies { get; set; }

		public ApplicationContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CloudMiningDB;Trusted_connection=True");
		}
	}
}
