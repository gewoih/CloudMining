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
	public class PayoutSharesViewModel : BaseViewModel
	{
		#region Constructor
		public PayoutSharesViewModel()
		{
			_PayoutSharesRepository = new PayoutSharesRepository(new BaseDataContext());

			PayoutShares = new ObservableCollection<PayoutShare>(_PayoutSharesRepository.GetAll());
		}
		#endregion

		#region Properties
		private readonly IRepository<PayoutShare> _PayoutSharesRepository;

		private ObservableCollection<PayoutShare> _PayoutShares;
		public ObservableCollection<PayoutShare> PayoutShares
		{
			get => _PayoutShares;
			set => Set(ref _PayoutShares, value);
		}
		#endregion
	}
}
