using CloudMining.DataContext;
using CloudMining.Models.Base;
using CloudMining.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CloudMining.Models
{
	public class Member : NamedEntity
	{
		private Role _Role;
		public Role Role
		{
			get => _Role;
			set => Set(ref _Role, value);
		}

		private DateTime _JoinDate;
		public DateTime JoinDate
		{
			get => _JoinDate;
			set => Set(ref _JoinDate, value);
		}

		private List<Deposit> _Deposits;
		public List<Deposit> Deposits
		{
			get => _Deposits;
			set => Set(ref _Deposits, value);
		}

		[NotMapped]
		public double DepositsAmount => Deposits.Sum(d => d.Amount);
		public double Share => Math.Round(DepositsAmount / new DepositsRepository(new BaseDataContext()).GetAll().Sum(d => d.Amount) * 100, 2); 
	}
}
