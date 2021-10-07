using CloudMining.Models.Base;
using System.Collections.Generic;

namespace CloudMining.Models
{
	internal class Role : NamedEntity
	{
		public double Fee { get; set; }
		public virtual List<Member> Members { get; set; }
	}
}
