using CloudMining.Models.Base;
using System;

namespace CloudMining.Models
{
	public class Deposit : Entity
	{
		private Member _Member;
		public Member Member
		{
			get => _Member;
			set => Set(ref _Member, value);
		}

		private DateTime _Date;
		public DateTime Date
		{
			get => _Date;
			set => Set(ref _Date, value);
		}

		private double _Amount;
		public double Amount
		{
			get => _Amount;
			set => Set(ref _Amount, value);
		}

		private string _Comment;
		public string Comment
		{
			get => _Comment;
			set => Set(ref _Comment, value);
		}
	}
}
