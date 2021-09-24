using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining
{
	public class Member
	{
		public int id { get; set; }
		public int type { get; set; }
		public string name { get; set; }
		public DateTime joinDate { get; set; }
		public double fee { get; set; }

		public Member(int _id, int _type, string _name, DateTime _joinDate, double _fee)
		{
			this.id = _id;
			this.type = _type;
			this.name = _name;
			this.joinDate = _joinDate;
			this.fee = _fee;
		}
	}
}
