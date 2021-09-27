using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining.ViewModels
{
	public class Invoice : AOperation
	{
		public override int id { get; set; }
		public override int operationType { get; set; }
		public override int currencyId { get; set; }
		public override DateTime date { get; set; }
		public override double amount { get; set; }
		public override string comment { get; set; }
		public int toMemberId { get; set; }
		public int fromMemberId { get; set; }

		public Invoice(int id, int operationType, int currencyId, DateTime date, double amount, int toMemberId, int fromMemberId) : base(id, operationType, currencyId, date, amount)
		{
			this.toMemberId = toMemberId;
			this.fromMemberId = fromMemberId;
		}
	}
}
