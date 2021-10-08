using CloudMining.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CloudMining.Models.DataWorkers
{
	internal static class MemberWorker
	{
		public static void CreateMember(string name, Role role, string joinDate)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				Member newMember = new Member
				{
					Name = name,
					RoleId = role.Id,
					JoinDate = joinDate
				};
				db.Members.Add(newMember);
				db.SaveChanges();
			}
		}

		public static List<Member> GetMembers()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var members = db.Members.Include(m => m.Role).Include(m => m.Deposits).ToList();
				return members;
			}
		}

		public static bool DeleteMember(Member member)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				if (db.Members.Find(member) != null)
				{
					db.Members.Remove(member);
					db.SaveChanges();
					return true;
				}
				else
					return false;
			}
		}
	}
}
