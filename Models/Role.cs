using CloudMining.Models.Base;
using System.Collections.Generic;

namespace CloudMining.Models
{
	public class Role : NamedEntity
	{
		public double Fee { get; set; }
		public virtual List<Member> Members { get; set; }
	}
}
