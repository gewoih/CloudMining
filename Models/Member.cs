using System.Collections.Generic;

namespace CloudMining.Models
{
	internal class Member
	{
		public int id { get; set; }
		public int? RoleId { get; set; }
		public virtual Role Role { get; set; }
		public string name { get; set; }
		public string joinDate { get; set; }
		public virtual List<Deposit> Deposits { get; set; } = new List<Deposit>();
	}
}
