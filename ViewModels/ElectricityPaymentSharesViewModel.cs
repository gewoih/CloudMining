using CloudMining.DataContext;
using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using CloudMining.Models.Repositories;
using CloudMining.Models.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	public class ElectricityPaymentSharesViewModel : BaseViewModel
	{
		#region Constructor
		public ElectricityPaymentSharesViewModel()
		{
			_ElectricityPaymentSharesRepository = new ElectricityPaymentSharesRepository(new BaseDataContext());

			ElectricityPaymentShares = new ObservableCollection<ElectricityPaymentShare>(_ElectricityPaymentSharesRepository.GetAll());

			CompleteElectricityPaymentShareCommand = new RelayCommand(OnCompleteElectricityPaymentShareCommandExecuted, CanCompleteElectricityPaymentShareCommandExecute);
		}
		#endregion

		#region Properties
		private readonly IRepository<ElectricityPaymentShare> _ElectricityPaymentSharesRepository;

		private ObservableCollection<ElectricityPaymentShare> _ElectricityPaymentShares;
		public ObservableCollection<ElectricityPaymentShare> ElectricityPaymentShares
		{
			get => _ElectricityPaymentShares;
			set => Set(ref _ElectricityPaymentShares, value);
		}

		private ElectricityPaymentShare _SelectedElectricityPaymentShare;
		public ElectricityPaymentShare SelectedElectricityPaymentShare
		{
			get => _SelectedElectricityPaymentShare;
			set => Set(ref _SelectedElectricityPaymentShare, value);
		}
		#endregion

		#region Commands
		public ICommand CompleteElectricityPaymentShareCommand { get; }
		private bool CanCompleteElectricityPaymentShareCommandExecute(object p) => SelectedElectricityPaymentShare != null;
		private void OnCompleteElectricityPaymentShareCommandExecuted(object p)
		{
			DialogResult dialogResult = MessageBox.Show($"Участник [{SelectedElectricityPaymentShare.Member.Name}] действительно перевел [{SelectedElectricityPaymentShare.Amount}р.] за электричество?",
														"Подтверждение перевода платежа за электричество",
														MessageBoxButtons.YesNo);

			if (dialogResult == DialogResult.Yes)
			{
				this.SelectedElectricityPaymentShare.IsDone = true;
				this._ElectricityPaymentSharesRepository.Update(SelectedElectricityPaymentShare.Id, SelectedElectricityPaymentShare);
			}
		}
		#endregion
	}
}
