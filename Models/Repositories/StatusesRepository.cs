using CloudMining.DataContext;
using CloudMining.Models.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining.Models.Repositories
{
	public class StatusesRepository : BaseRepository<Status>
	{
		public StatusesRepository(BaseDataContext dbContext) : base(dbContext) { }
	}
}
