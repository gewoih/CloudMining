using CloudMining.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CloudMining.Models
{
	public class Payout : Entity
	{
		private string _TxId;
		public string TxId
		{
			get => _TxId;
			set => Set(ref _TxId, value);
		}

		private double _Timestamp;
		public double Timestamp
		{
			get => _Timestamp;
			set => Set(ref _Timestamp, value);
		}

		private double _Amount;
		public double Amount
		{
			get => _Amount;
			set => Set(ref _Amount, value);
		}

		private Currency _Currency;
		public Currency Currency
		{
			get => _Currency;
			set => Set(ref _Currency, value);
		}

		private List<PayoutShare> _Shares;
		public List<PayoutShare> Shares
		{
			get => _Shares;
			set => Set(ref _Shares, value);
		}

		[NotMapped]
		public DateTime Date => new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(this.Timestamp).ToLocalTime();
		public bool IsDone => Shares.Count(s => s.IsDone == true) == Shares.Count;
	}
}