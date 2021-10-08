using CloudMining.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudMining.Models.DataWorkers
{
	class DepositWorker
	{
		public static void CreateDeposit(Deposit newDeposit)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				db.Deposits.Add(newDeposit);
				db.SaveChanges();
			}
		}

		public static List<Deposit> GetDeposits()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var deposits = db.Deposits.Include(d => d.Member).ToList();
				return deposits;
			}
		}
	}
}
