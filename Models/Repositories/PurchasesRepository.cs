using CloudMining.DataContext;
using CloudMining.Models.Repositories.Base;

namespace CloudMining.Models.Repositories
{
	public class PurchasesRepository : BaseRepository<Purchase>
	{
		public PurchasesRepository(BaseDataContext dbContext) : base(dbContext) { }
	}
}
