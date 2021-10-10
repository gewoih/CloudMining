using CloudMining.Models.DataWorkers.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudMining.Models.DataWorkers
{
	public class RolesDataWorker : BaseDataWorker<Role>
	{
		public override IQueryable<Role> GetAll()
		{
			return base.GetAll().Include(item => item.Members);
		}
	}
}
