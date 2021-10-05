using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining.Models
{
	internal abstract class AOperation
	{
		public abstract int id { get; set; }
		public abstract string date { get; set; }
		public abstract double amount { get; set; }
		public abstract string comment { get; set; }

		protected AOperation(int id, string date, double amount, string comment)
		{
			this.id = id;
			this.date = date;
			this.amount = amount;
			this.comment = comment;
		}
	}
}
