using CloudMining.Models.Base;
using System;

namespace CloudMining.Models
{
	public class Device : NamedEntity
	{
		public DateTime PurchaseDate { get; set; }
		public double Hashrate { get; set; }
		public Currency Currency { get; set; }
		public int Consumption { get; set; }
	}
}
