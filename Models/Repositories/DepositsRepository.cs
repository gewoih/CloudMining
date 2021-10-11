using CloudMining.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CloudMining.Models.Repositories.Base
{
	public class DepositsRepository : BaseRepository<Deposit>
	{
		public DepositsRepository(BaseDataContext dbContext) : base(dbContext) { }

		public override IQueryable<Deposit> GetAll()
		{
			return base.GetAll().Include(item => item.Member);
		}
	}
}
