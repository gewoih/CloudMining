using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	internal class DepositsViewModel : BaseViewModel
	{
		#region Constructor
		public DepositsViewModel()
		{
			AddNewDepositCommand = new RelayCommand(OnAddNewDepositCommandExecuted, CanAddNewDepositCommandExecute);
			LoadDepositsCommand = new RelayCommand(OnLoadDepositsCommandExecuted, CanLoadDepositsCommandExecute);
			LoadDepositsCommand.Execute(null);
		}
		#endregion

		#region Properties
		private ObservableCollection<Deposit> _depositsList = new ObservableCollection<Deposit>();
		public ObservableCollection<Deposit> DepositsList
		{
			get => _depositsList;
			set => Set(ref _depositsList, value);
		}
		#endregion

		#region Commands

		#region LoadDepositsCommand
		public ICommand LoadDepositsCommand { get; }
		private bool CanLoadDepositsCommandExecute(object p) => true;
		private void OnLoadDepositsCommandExecuted(object p)
		{
		}
		#endregion

		#region AddNewDepositCommand
		public ICommand AddNewDepositCommand { get; }
		private bool CanAddNewDepositCommandExecute(object p) => true;
		private void OnAddNewDepositCommandExecuted(object p)
		{
			//NewMemberForm newForm = new NewMemberForm();

			//if (newForm.ShowDialog() == true)
			{
				//this.LoadDepositsCommand.Execute(null);

				MessageBox.Show("Участник создан!");
			}
		}
		#endregion

		#endregion
	}
}
