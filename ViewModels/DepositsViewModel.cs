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
			SQL connection = new SQL();
			this.DepositsList.Clear();

			SqlDataReader reader = connection.Execute("select operations.id, members.name as member, operations.date, operations.amount, operations.comment from operations join members on operations.from_member_id=members.id where operations.operation_type=1");
			while (reader.Read())
			{
				this.DepositsList.Add(new Deposit(Convert.ToInt32(reader["id"]),
													reader["date"].ToString(),
													Convert.ToDouble(reader["amount"]),
													reader["comment"].ToString(),
													reader["member"].ToString()));
			}
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
