using CloudMining.Data;
using System.Collections.Generic;
using System.Linq;

namespace CloudMining.Models
{
	internal static class DataWorker
	{
		#region Member
		public static void CreateMember(Member newMember)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				db.Members.Add(newMember);
				db.SaveChanges();
			}
		}

		public static List<Member> GetMembers()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				return db.Members.ToList();
			}
		}
		#endregion

		#region Deposit
		public static void CreateDeposit(Deposit newDeposit)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				db.Deposits.Add(newDeposit);
				db.SaveChanges();
			}
		}

		public static List<Deposit> GetDeposits()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				return db.Deposits.ToList();
			}
		}
		#endregion

		#region Device
		public static void CreateDevice(Device newDevice)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				db.Devices.Add(newDevice);
				db.SaveChanges();
			}
		}

		public static List<Device> GetDevices()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				return db.Devices.ToList();
			}
		}
		#endregion

		#region Role
		public static void CreateRole(Role newRole)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				db.Roles.Add(newRole);
				db.SaveChanges();
			}
		}

		public static List<Role> GetRoles()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				return db.Roles.ToList();
			}
		}

		public static List<string> GetRolesNames()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				return db.Roles.Select(r => r.name).ToList();
			}
		}
		#endregion
	}
}
