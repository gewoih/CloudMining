using CloudMining.Models.Base;
using System;

namespace CloudMining.Models
{
	public class Device : NamedEntity
	{
		private DateTime _PurchaseDate;
		public DateTime PurchaseDate
		{
			get => _PurchaseDate;
			set => Set(ref _PurchaseDate, value);
		}

		private double _Hashrate;
		public double Hashrate
		{
			get => _Hashrate;
			set => Set(ref _Hashrate, value);
		}

		private Currency _Currency;
		public Currency Currency
		{
			get => _Currency;
			set => Set(ref _Currency, value);
		}

		private int _Consumption;
		public int Consumption
		{
			get => _Consumption;
			set => Set(ref _Consumption, value);
		}
	}
}
