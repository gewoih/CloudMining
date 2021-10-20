using CloudMining.DataContext;
using CloudMining.Models.Repositories.Base;
using System.Linq;

namespace CloudMining.Models.Repositories
{
	public class ElectricityPaymentSharesRepository : BaseRepository<ElectricityPaymentShare>
	{
		public ElectricityPaymentSharesRepository(BaseDataContext dbContext) : base(dbContext) { }
	}
}
