using CloudMining.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudMining.DataContext
{
	public class BaseDataContext : DbContext
	{
		public DbSet<Member> Members { get; set; }
		public DbSet<Deposit> Deposits { get; set; }
		public DbSet<Device> Devices { get; set; }
		public DbSet<Currency> Currencies { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Purchase> Purchases { get; set; }

		public BaseDataContext()
		{
			/*Database.EnsureDeleted();
			Database.EnsureCreated();

			var r1 = new Role { Name = "Участник", Fee = 0 };
			var r2 = new Role { Name = "Администратор", Fee = 3 };
			var r3 = new Role { Name = "Менеджер", Fee = 5 };
			Roles.AddRange(r1, r2, r3);

			var c1 = new Currency { Name = "Bitcoin", ShortName = "BTC" };
			var c2 = new Currency { Name = "Ethereum", ShortName = "ETH" };
			var c3 = new Currency { Name = "Litecoin", ShortName = "LTC" };
			var c4 = new Currency { Name = "Dogecoin", ShortName = "DOGE" };
			Currencies.AddRange(c1, c2, c3, c4);

			var m1 = new Member { Name = "Никита Раненко", JoinDate = "24.04.2001", Role = r3 };
			var m2 = new Member { Name = "Максим Григорьев", JoinDate = "24.04.2001", Role = r1 };
			var m3 = new Member { Name = "Егор Коняев", JoinDate = "24.04.2001", Role = r1 };
			var m4 = new Member { Name = "Иван Кулагин", JoinDate = "24.04.2001", Role = r1 };
			var m5 = new Member { Name = "Максим Раненко", JoinDate = "24.04.2001", Role = r2 };
			var m6 = new Member { Name = "Максим Глинкин", JoinDate = "24.04.2001", Role = r1 };
			Members.AddRange(m1, m2, m3, m4, m5, m6);

			var d1 = new Device { Name = "Antminer S17 Pro", PurchaseDate = "12.08.2021", Currency = c1, Consumption = 2500, Hashrate = 54 };
			var d2 = new Device { Name = "Antminer S9i", PurchaseDate = "12.08.2021", Currency = c1, Consumption = 1500, Hashrate = 16 };
			var d3 = new Device { Name = "Antminer L3++", PurchaseDate = "12.08.2021", Currency = c3, Consumption = 1200, Hashrate = 620 };
			var d4 = new Device { Name = "Whatsminer M20S", PurchaseDate = "12.08.2021", Currency = c1, Consumption = 3400, Hashrate = 68 };
			var d5 = new Device { Name = "NVIDIA RTX 3070", PurchaseDate = "12.08.2021", Currency = c2, Consumption = 135, Hashrate = 62 };
			Devices.AddRange(d1, d2, d3, d4, d5);

			var dep1 = new Deposit { Member = m1, Amount = 439274, Date = "12.10.2021" };
			var dep2 = new Deposit { Member = m2, Amount = 410525, Date = "12.10.2021" };
			var dep3 = new Deposit { Member = m3, Amount = 259520.28, Date = "12.10.2021" };
			var dep4 = new Deposit { Member = m4, Amount = 91563, Date = "12.10.2021" };
			var dep5 = new Deposit { Member = m5, Amount = 244780, Date = "12.10.2021" };
			var dep6 = new Deposit { Member = m6, Amount = 133821, Date = "12.10.2021" };
			Deposits.AddRange(dep1, dep2, dep3, dep4, dep5, dep6);

			var p1 = new Purchase { Date = "24.04.2001", Amount = 2300, Subject = "Строительные материалы" };
			var p2 = new Purchase { Date = "24.04.2001", Amount = 300000, Subject = "Whatsminer M20S" };
			var p3 = new Purchase { Date = "24.04.2001", Amount = 9500, Subject = "Вытяжка для домика" };
			var p4 = new Purchase { Date = "24.04.2001", Amount = 6200, Subject = "Стеллаж для майнеров" };
			Purchases.AddRange(p1, p2, p3, p4);

			SaveChanges();*/
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CloudMiningDB;Trusted_Connection=True;");
		}
	}
}
