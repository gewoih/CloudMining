using System.Collections.Generic;

namespace CloudMining.Models
{
	internal class Currency
	{
		public int id { get; set; }
		public string shortName { get; set; }
		public string longName { get; set; }
		public virtual List<Device> Devices { get; set; }

		public Currency()
		{
			this.Devices = new List<Device>();
		}
	}
}
