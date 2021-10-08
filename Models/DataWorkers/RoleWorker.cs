using CloudMining.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CloudMining.Models.DataWorkers
{
	internal static class RoleWorker
	{
		public static List<Role> GetRoles()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var roles = db.Roles.Include(r => r.Members).ToList();
				return roles;
			}
		}
	}
}
