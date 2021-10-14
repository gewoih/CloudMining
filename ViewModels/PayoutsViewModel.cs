using CloudMining.DataContext;
using CloudMining.Models;
using CloudMining.Models.Repositories;
using CloudMining.Models.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CloudMining.ViewModels
{
	public class PayoutsViewModel : BaseViewModel
	{
		#region Constructor
		public PayoutsViewModel()
		{
			this._PayoutsRepository = new PayoutsRepository(new BaseDataContext());

			Payouts = new ObservableCollection<Payout>(_PayoutsRepository.GetAll());
		}
		#endregion

		#region Properties
		private readonly IRepository<Payout> _PayoutsRepository;

		private ObservableCollection<Payout> _Payouts;
		public ObservableCollection<Payout> Payouts
		{
			get => _Payouts;
			set => Set(ref _Payouts, value);
		}
		#endregion
	}
}
