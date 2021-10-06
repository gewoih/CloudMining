using CloudMining.Data;
using System.Collections.Generic;
using System.Linq;

namespace CloudMining.Models
{
	internal static class DataWorker
	{
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
	}
}
