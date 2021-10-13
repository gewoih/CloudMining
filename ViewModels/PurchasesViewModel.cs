using CloudMining.DataContext;
using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using CloudMining.Models.Repositories;
using CloudMining.Models.Repositories.Base;
using CloudMining.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	public class PurchasesViewModel : BaseViewModel
	{
		#region Constructor
		public PurchasesViewModel()
		{
			this._PurchasesRepository = new PurchasesRepository(new BaseDataContext());
			this.Purchases = new ObservableCollection<Purchase>(_PurchasesRepository.GetAll());

			AddPurchaseCommand = new RelayCommand(OnAddPurchaseCommandExecuted, CanAddPurchaseCommandExecute);
			RemovePurchaseCommand = new RelayCommand(OnRemovePurchaseCommandExecuted, CanRemovePurchaseCommandExecute);
		}
		#endregion

		#region Properties
		private IRepository<Purchase> _PurchasesRepository;

		private ObservableCollection<Purchase> _Purchases;
		public ObservableCollection<Purchase> Purchases
		{
			get => _Purchases;
			set => Set(ref _Purchases, value);
		}

		private Purchase _SelectedPurchase;
		public Purchase SelectedPurchase
		{
			get => _SelectedPurchase;
			set => Set(ref _SelectedPurchase, value);
		}
		#endregion

		#region Commands
		public ICommand AddPurchaseCommand { get; }
		private bool CanAddPurchaseCommandExecute(object p) => true;
		private void OnAddPurchaseCommandExecuted(object p)
		{
			var newPurchase = new Purchase();
			var newForm = new NewPurchaseForm(newPurchase);

			if (newForm.ShowDialog() == true)
			{
				this._PurchasesRepository.Create(newPurchase);
				this._Purchases.Add(newPurchase);
				this.SelectedPurchase = newPurchase;
			}
		}

		public ICommand RemovePurchaseCommand { get; }
		private bool CanRemovePurchaseCommandExecute(object p) => SelectedPurchase != null;
		private void OnRemovePurchaseCommandExecuted(object p)
		{
			DialogResult dialogResult = MessageBox.Show($"Вы действительно хотите удалить покупку {SelectedPurchase.Id} на сумму {SelectedPurchase.Amount}р.?",
														"Удаления покупки",
														MessageBoxButtons.YesNo);

			if (dialogResult == DialogResult.Yes)
			{
				this._PurchasesRepository.Delete(SelectedPurchase.Id);
				this.Purchases.Remove(SelectedPurchase);

				MessageBox.Show("покупка удалена.");
			}
		}
		#endregion
	}
}
