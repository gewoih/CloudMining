using CloudMining.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudMining.Models
{
	public class Member : NamedEntity
	{
		public int RoleId { get; set; }
		public virtual Role Role { get; set; }
		public string JoinDate { get; set; }
		public virtual List<Deposit> Deposits { get; set; }
	}
}
