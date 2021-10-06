using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using CloudMining.Views.Windows;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	internal class MembersViewModel : BaseViewModel
	{
		#region Constructor
		public MembersViewModel()
		{
			AddNewMemberCommand = new RelayCommand(OnAddNewMemberCommandExecuted, CanAddNewMemberCommandExecute);
			LoadMembersCommand = new RelayCommand(OnLoadMembersCommandExecuted, CanLoadMembersCommandExecute);
			LoadMembersCommand.Execute(null);
		}
		#endregion

		#region Properties
		private ObservableCollection<Member> _membersList = new ObservableCollection<Member>();
		public ObservableCollection<Member> MembersList
		{
			get => _membersList;
			set => Set(ref _membersList, value);
		}
		#endregion

		#region Commands

		#region LoadMembersCommand
		public ICommand LoadMembersCommand { get; }
		private bool CanLoadMembersCommandExecute(object p) => true;
		private void OnLoadMembersCommandExecuted(object p)
		{

		}
		#endregion

		#region AddNewMemberCommand
		public ICommand AddNewMemberCommand { get; }
		private bool CanAddNewMemberCommandExecute(object p) => true;
		private void OnAddNewMemberCommandExecuted(object p)
		{
			NewMemberForm newForm = new NewMemberForm();

			if (newForm.ShowDialog() == true)
			{
				this.LoadMembersCommand.Execute(null);

				MessageBox.Show("Участник создан!");
			}
		}
		#endregion

		#endregion
	}
}
