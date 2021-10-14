using CloudMining.DataContext;
using CloudMining.Models.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudMining.Models.Repositories
{
	public class PayoutSharesRepository : BaseRepository<PayoutShare>
	{
		public PayoutSharesRepository(BaseDataContext dbContext) : base(dbContext) { }

		public override IQueryable<PayoutShare> GetAll()
		{
			return base.GetAll().Include(item => item.Member).Include(item => item.Payout.Currency).Include(item => item.Status);
		}
	}
}
