using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining
{
	public abstract class Operation
	{
		protected int id { get; set; }
		protected int operationType { get; set; }
		protected int toMemberId { get; set; }
		protected int currencyId { get; set; }
		protected DateTime date { get; set; }
		protected double amount { get; set; }
	}
}
