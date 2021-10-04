using System;

namespace CloudMining.Models
{
	internal class Device
	{
		public int id { get; set; }
		public string workerName { get; set; }
		public DateTime purchaseDate { get; set; }
		public double hashrate { get; set; }
		public string currency { get; set; }
		public int consumption { get; set; }

		public Device(int _id, string _workerName, DateTime _purchaseDate, double _hashrate, string _currency, int _consumption)
		{
			this.id = _id;
			this.workerName = _workerName;
			this.purchaseDate = _purchaseDate;
			this.hashrate = _hashrate;
			this.currency = _currency;
			this.consumption = _consumption;
		}
	}
}
