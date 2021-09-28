using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMining.Models
{
	internal class Member
	{
		public int id { get; set; }
		public string role { get; set; }
		public string name { get; set; }
		public DateTime joinDate { get; set; }
		public double fee { get; set; }
	}
}
