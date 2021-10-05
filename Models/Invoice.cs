using System;

namespace CloudMining.Models
{
	internal class Invoice : AOperation
	{
		public override int id { get; set; }
		public override string date { get; set; }
		public override double amount { get; set; }
		public override string comment { get; set; }
		public int fromMemberId { get; set; }
		public int toMemberId { get; set; }

		public Invoice(
			int id,
			string date,
			double amount,
			string comment,
			int fromMemberId,
			int toMemberId) : base(id, date, amount, comment)
		{
			this.fromMemberId = fromMemberId;
			this.toMemberId = toMemberId;
		}
	}
}
