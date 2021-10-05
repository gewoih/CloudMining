using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining.Models
{
	internal class Purchase : AOperation
	{
		public override int id { get; set; }
		public override string date { get; set; }
		public override double amount { get; set; }
		public override string comment { get; set; }

		public Purchase(
			int id,
			string date,
			double amount,
			string comment) : base(id, date, amount, comment) { }
	}
}
