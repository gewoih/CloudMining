using CloudMining.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CloudMining.Models.Repositories.Base
{
	public class DevicesRepository : BaseRepository<Device>
	{
		public DevicesRepository(BaseDataContext dbContext) : base(dbContext) { }

		public override IQueryable<Device> GetAll()
		{
			return base.GetAll().Include(item => item.Currency);
		}
	}
}
