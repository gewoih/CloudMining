using System;

namespace CloudMining.Models
{
	internal class Device
	{
		public int id { get; set; }
		public string workerName { get; set; }
		public DateTime purchaseDate { get; set; }
		public double hashrate { get; set; }
		public int? CurrencyId { get; set; }
		public virtual Currency Currency { get; set; }
		public int consumption { get; set; }
	}
}
