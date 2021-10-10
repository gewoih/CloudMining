﻿using CloudMining.Models.Base;

namespace CloudMining.Models
{
	public class Deposit : Entity
	{
		public int MemberId { get; set; }
		public virtual Member Member { get; set; }
		public string Date { get; set; }
		public double Amount { get; set; }
		public string Comment { get; set; }
	}
}
