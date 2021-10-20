using CloudMining.DataContext;
using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using CloudMining.Models.Repositories;
using CloudMining.Models.Repositories.Base;
using CloudMining.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	public class ElectricityPaymentsViewModel : BaseViewModel
	{
		#region Constructor
		public ElectricityPaymentsViewModel()
		{
			this._ElectricityPaymentsRepository = new ElectricityPaymentsRepository(new BaseDataContext());

			this.ElectricityPayments = new ObservableCollection<ElectricityPayment>(this._ElectricityPaymentsRepository.GetAll());

			AddElectricityPaymentCommand = new RelayCommand(OnAddElectricityPaymentCommandExecuted, CanAddElectricityPaymentCommandExecute);
		}
		#endregion

		#region Properties
		private readonly IRepository<ElectricityPayment> _ElectricityPaymentsRepository;

		private ObservableCollection<ElectricityPayment> _ElectricityPayments;
		public ObservableCollection<ElectricityPayment> ElectricityPayments
		{
			get => _ElectricityPayments;
			set => Set(ref _ElectricityPayments, value);
		}
		#endregion

		#region Commands
		public ICommand AddElectricityPaymentCommand { get; }
		private bool CanAddElectricityPaymentCommandExecute(object p) => true;
		private void OnAddElectricityPaymentCommandExecuted(object p)
		{
			ElectricityPayment newPayment = new ElectricityPayment();
			NewElectricityPaymentForm newForm = new NewElectricityPaymentForm(newPayment);

			if (newForm.ShowDialog() == true)
			{
				this._ElectricityPaymentsRepository.Create(newPayment);
				this.ElectricityPayments.Add(newPayment);
			}
		}
		#endregion
	}
}
