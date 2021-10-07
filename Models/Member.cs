using CloudMining.Models.Base;
using System.Collections.Generic;

namespace CloudMining.Models
{
	internal class Member : NamedEntity
	{
		public int RoleId { get; set; }
		public virtual Role Role { get; set; }
		public string JoinDate { get; set; }
		public virtual List<Deposit> Deposits { get; set; }
	}
}
