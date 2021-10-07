using CloudMining.Models.Base;
using System.Collections.Generic;

namespace CloudMining.Models
{
	internal class Member : NamedEntity
	{
		public virtual Role Role { get; set; }
		public string joinDate { get; set; }
		public virtual List<Deposit> Deposits { get; set; }
	}
}
