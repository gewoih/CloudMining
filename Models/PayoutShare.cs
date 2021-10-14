using CloudMining.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining.Models
{
	public class PayoutShare : Entity
	{
		public Payout Payout { get; set; }
		public Member Member { get; set; }
		public double Percent { get; set; }
		public double Amount { get; set; }
		public Status Status { get; set; }
	}
}
