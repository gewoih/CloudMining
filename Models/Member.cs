using CloudMining.DataContext;
using CloudMining.Models.Base;
using CloudMining.Models.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CloudMining.Models
{
	public class Member : NamedEntity
	{
		public int RoleId { get; set; }
		public virtual Role Role { get; set; }
		public string JoinDate { get; set; }
		public virtual List<Deposit> Deposits { get; set; }

		[NotMapped]
		public double DepositsAmount => Deposits.Sum(d => d.Amount);
		public double Share => Math.Round(DepositsAmount / new DepositsRepository(new BaseDataContext()).GetAll().Sum(d => d.Amount) * 100, 2); 
	}
}
