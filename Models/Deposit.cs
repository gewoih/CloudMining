using System;

namespace CloudMining.Models
{
	internal class Deposit
	{
		public int id { get; set; }
		public int memberId { get; set; }
		public Member Member { get; set; }
		public DateTime date { get; set; }
		public double amount { get; set; }
		public string comment { get; set; }
	}
}
