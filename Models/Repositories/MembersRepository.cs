using CloudMining.DataContext;
using CloudMining.Models.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CloudMining.Models.Repositories.Base
{
	public class MembersRepository : BaseRepository<Member>
	{
		public MembersRepository(BaseDataContext dbContext) : base(dbContext) { }

		public override IQueryable<Member> GetAll()
		{
			return base.GetAll().Include(item => item.Role).Include(item => item.Deposits);
		}
	}
}
