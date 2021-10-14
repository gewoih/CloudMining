using CloudMining.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining.Models
{
	public class PayoutShares : Entity
	{
		public int PayoutId { get; set; }
		public virtual Payout Payout { get; set; }
		public int MemberId { get; set; }
		public virtual Member Member { get; set; }
		public double Share { get; set; }
		public double Amount { get; set; }
		public int StatusId { get; set; }
		public virtual Status Status { get; set; }
	}
}
