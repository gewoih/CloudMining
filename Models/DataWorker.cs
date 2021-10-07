using CloudMining.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CloudMining.Models
{
	internal static class DataWorker
	{
		#region Member
		public static void CreateMember(string _name, Role _role, string _joinDate)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				Member newMember = new Member
				{
					Name = _name,
					RoleId = _role.Id,
					JoinDate = _joinDate
				};
				db.Members.Add(newMember);
				db.SaveChanges();
			}
		}

		public static List<Member> GetMembers()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var members = db.Members.ToList();
				return members;
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
				var deposits = db.Deposits.ToList();
				return deposits;
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
				var devices = db.Devices.ToList();
				return devices;
			}
		}
		#endregion

		#region Role
		public static void CreateRole(string name, double fee)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				Role newRole = new Role
				{
					Name = name,
					Fee = fee
				};
				db.Roles.Add(newRole);
				db.SaveChanges();
			}
		}

		public static List<Role> GetRoles()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var roles = db.Roles.ToList();
				return roles;
			}
		}
		#endregion
	}
}
