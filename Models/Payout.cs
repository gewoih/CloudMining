using CloudMining.Models.Base;
using System.Collections.Generic;

namespace CloudMining.Models
{
	public class Payout : Entity
	{
		public string TxId { get; set; }
		public double Timestamp { get; set; }
		public double Amount { get; set; }
		public int CurrencyId { get; set; }
		public virtual Currency Currency { get; set; }
		public Dictionary<Member, double> Shares { get; set; }
	}
}
