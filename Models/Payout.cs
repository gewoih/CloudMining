﻿using CloudMining.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudMining.Models
{
	public class Payout : Entity
	{
		public string TxId { get; set; }
		public double Timestamp { get; set; }
		public double Amount { get; set; }
		public int CurrencyId { get; set; }
		public virtual Currency Currency { get; set; }
		public virtual List<PayoutShares> Shares { get; set; }

		[NotMapped]
		public string Date => new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(this.Timestamp).ToLocalTime().ToString("dd.MM.yyyy HH:mm");
	}
}
