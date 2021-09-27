using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining
{
	public class Payout : AOperation
	{
		public override int id { get; set; }
		public override int operationType { get; set; }
		public override int currencyId { get; set; }
		public override DateTime date { get; set; }
		public override double amount { get; set; }
		public override string comment { get; set; }

		public Payout(int id, int operationType, int currencyId, DateTime date, double amount) : base(id, operationType, currencyId, date, amount)
		{ }
	}
}
