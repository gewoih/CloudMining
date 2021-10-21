using CloudMining.Models.Base;
using System;

namespace CloudMining.Models
{
	public class Purchase : Entity
	{
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

		private string _Subject;
		public string Subject
		{
			get => _Subject;
			set => Set(ref _Subject, value);
		}

		private bool _IsMandatory = false;
		public bool IsMandatory
		{
			get => _IsMandatory;
			set => Set(ref _IsMandatory, value);
		}
	}
}
