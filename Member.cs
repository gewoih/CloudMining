using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining
{
	public class Member
	{
		public int id { get; set; }
		public string role { get; set; }
		public string name { get; set; }
		public DateTime joinDate { get; set; }
		public double fee { get; set; }

		public Member(int id, string role, string name, DateTime joinDate, double fee)
		{
			this.id = id;
			this.role = role;
			this.name = name;
			this.joinDate = joinDate;
			this.fee = fee;
		}
	}
}
