using CloudMining.Models.Base;
using System;

namespace CloudMining.Models
{
	public class Purchase : Entity
	{
		public DateTime Date { get; set; }
		public double Amount { get; set; }
		public string Subject { get; set; }
	}
}
