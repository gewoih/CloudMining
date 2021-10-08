using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using CloudMining.Models.DataWorkers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	internal class NewMemberViewModel : BaseViewModel
	{
		#region Constructor
		public NewMemberViewModel()
		{
			AddNewMemberCommand = new RelayCommand(OnAddNewMemberCommandExecuted, CanAddNewMemberCommandExecute);
		}
		#endregion

		#region Properties
		private ObservableCollection<Role> _rolesList = new ObservableCollection<Role>(RoleWorker.GetRoles());
		public ObservableCollection<Role> RolesList
		{
			get => _rolesList;
			set => Set(ref _rolesList, _rolesList);
		}

		private string _name;
		public string Name
		{
			get => _name;
			set => Set(ref _name, value);
		}

		private string _role;
		public string Role
		{
			get => _role;
			set => Set(ref _role, value);
		}

		private string _joinDate;
		public string JoinDate
		{
			get => _joinDate;
			set => Set(ref _joinDate, value);
		}
		#endregion

		#region Commands

		#region AddNewMember
		public ICommand AddNewMemberCommand { get; }
		private bool CanAddNewMemberCommandExecute(object p) => true;
		private void OnAddNewMemberCommandExecuted(object p)
		{
			if (!this.Name.Equals(String.Empty) && !this.Role.Equals(String.Empty) && DateTime.Parse(this.JoinDate) <= DateTime.Now)
			{
				CreateMember(Name, RolesList.FirstOrDefault(r => r.Name == this.Role), JoinDate);
			}
			else
				MessageBox.Show("Введите корректные данные!");
		}
		#endregion

		#endregion
	}
}
