using System.Collections.Generic;

namespace CloudMining.Models
{
	internal class Member
	{
		public int id { get; set; }
		public int roleId { get; set; }
		public virtual Role Role { get; set; }
		public string name { get; set; }
		public string joinDate { get; set; }
		public List<Deposit> Deposits { get; set; }

		public Member(int roleId, string name, string joinDate)
		{
			this.roleId = roleId;
			this.name = name;
			this.joinDate = joinDate;
			this.Deposits = new List<Deposit>();
		}
	}
}
