using System.Collections.Generic;

namespace CloudMining.Models
{
	internal class Member
	{
		public int id { get; set; }
		public int role { get; set; }
		public string name { get; set; }
		public string joinDate { get; set; }
		public List<Deposit> Deposits { get; set; }
	}
}
