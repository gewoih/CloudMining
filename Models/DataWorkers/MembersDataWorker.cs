using CloudMining.Models.DataWorkers.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudMining.Models.DataWorkers
{
	public class MembersDataWorker : BaseDataWorker<Member>
	{
		public override IQueryable<Member> GetAll()
		{
			return base.GetAll().Include(item => item.Role).Include(item => item.Deposits);
		}
	}
}
