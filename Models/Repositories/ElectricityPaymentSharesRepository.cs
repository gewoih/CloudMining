using CloudMining.DataContext;
using CloudMining.Models.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CloudMining.Models.Repositories
{
	public class ElectricityPaymentSharesRepository : BaseRepository<ElectricityPaymentShare>
	{
		public ElectricityPaymentSharesRepository(BaseDataContext dbContext) : base(dbContext) { }

		public override IQueryable<ElectricityPaymentShare> GetAll()
		{
			return base.GetAll().Include(p => p.BaseEntity).Include(p => p.Member);
		}
	}
}
