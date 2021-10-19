using CloudMining.DataContext;
using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using CloudMining.Models.Repositories;
using CloudMining.Models.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	public class PayoutSharesViewModel : BaseViewModel
	{
		#region Constructor
		public PayoutSharesViewModel()
		{
			_PayoutSharesRepository = new PayoutSharesRepository(new BaseDataContext());

			PayoutShares = new ObservableCollection<PayoutShare>(_PayoutSharesRepository.GetAll());

			CompletePayoutShareCommand = new RelayCommand(OnCompletePayoutShareCommandExecuted, CanCompletePayoutShareCommandExecute);
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

		private PayoutShare _SelectedPayoutShare;
		public PayoutShare SelectedPayoutShare
		{
			get => _SelectedPayoutShare;
			set => Set(ref _SelectedPayoutShare, value);
		}
		#endregion

		#region Commands
		public ICommand CompletePayoutShareCommand { get; }
		private bool CanCompletePayoutShareCommandExecute(object p) => SelectedPayoutShare != null;
		private void OnCompletePayoutShareCommandExecuted(object p)
		{
			DialogResult dialogResult = MessageBox.Show($"Доля [{SelectedPayoutShare.Id}] действительно переведена участнику [{SelectedPayoutShare.Member.Name}]?",
														"Подтверждение перевода выплаты",
														MessageBoxButtons.YesNo);

			if (dialogResult == DialogResult.Yes)
			{
				this.SelectedPayoutShare.IsDone = true;
				this._PayoutSharesRepository.Update(SelectedPayoutShare.Id, SelectedPayoutShare);
			}
		}
		#endregion
	}
}
