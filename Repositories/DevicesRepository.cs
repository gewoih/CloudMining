using CloudMining.DataContext;
using CloudMining.Models;
using CloudMining.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CloudMining.Repositories
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
