using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining.Models
{
	internal abstract class AOperation
	{
		public abstract int id { get; set; }
		public abstract int operationType { get; set; }
		public abstract int currencyId { get; set; }
		public abstract DateTime date { get; set; }
		public abstract double amount { get; set; }
		public abstract string comment { get; set; }

		protected AOperation(int id, int operationType, int currencyId, DateTime date, double amount, string comment)
		{
			this.id = id;
			this.operationType = operationType;
			this.currencyId = currencyId;
			this.date = date;
			this.amount = amount;
			this.comment = comment;
		}
	}
}
