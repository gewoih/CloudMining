using System;

namespace CloudMining.Models
{
	internal class Payout : AOperation
	{
		public override int id { get; set; }
		public override string date { get; set; }
		public override double amount { get; set; }
		public override string comment { get; set; }

		public Payout(
			int id,
			int currencyId,
			string date,
			double amount,
			string comment) : base(id, date, amount, comment) { }
	}
}
