using CloudMining.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMining.Models
{
	public class ElectricityPayment : Entity
	{
		private double _Amount;
		public double Amount
		{
			get => _Amount;
			set => Set(ref _Amount, value);
		}

		private DateTime _Date;
		public DateTime Date
		{
			get => _Date;
			set => Set(ref _Date, value);
		}

		private List<ElectricityPaymentShare> _Shares;
		public List<ElectricityPaymentShare> Shares
		{
			get => _Shares;
			set => Set(ref _Shares, value);
		}

		[NotMapped]
		public bool IsDone => Shares.Count(s => s.IsDone == true) == Shares.Count;
	}
}
