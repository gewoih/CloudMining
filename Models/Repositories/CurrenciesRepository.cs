using CloudMining.DataContext;
using CloudMining.Models.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CloudMining.Models.Repositories
{
	public class CurrenciesRepository : BaseRepository<Currency>
	{
		public override IQueryable<Currency> GetAll()
		{
			return base.GetAll().Include(item => item.Devices);
		}

		public CurrenciesRepository(BaseDataContext dbContext) : base(dbContext) { }
	}
}
