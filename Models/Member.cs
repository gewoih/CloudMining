using System;

namespace CloudMining.Models
{
	internal class Member
	{
		public int id { get; set; }
		public string role { get; set; }
		public string name { get; set; }
		public string joinDate { get; set; }
		public double invested { get; set; }

		public Member(int id, string role, string name, string joinDate, double invested)
		{
			this.id = id;
			this.role = role;
			this.name = name;
			this.joinDate = joinDate;
			this.invested = invested;
		}
	}
}
