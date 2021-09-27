using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining.ViewModels
{
	public class Device
	{
		public int id { get; set; }
		public string workerName { get; set; }
		public DateTime purchaseDate { get; set; }
		public double hashrate { get; set; }
		public int currencyId { get; set; }
		public int consumption { get; set; }

		public Device(int _id, string _workerName, DateTime _purchaseDate, double _hashrate, int _currencyId, int _consumption)
		{
			this.id = _id;
			this.workerName = _workerName;
			this.purchaseDate = _purchaseDate;
			this.hashrate = _hashrate;
			this.currencyId = _currencyId;
			this.consumption = _consumption;
		}
	}
}
