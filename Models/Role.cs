using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining.Models
{
	internal class Role
	{
		public int id { get; set; }
		public string name { get; set; }
		public double fee { get; set; }
		public virtual List<Member> Members { get; set; }

		public Role()
		{
			this.Members = new List<Member>();
		}
	}
}
