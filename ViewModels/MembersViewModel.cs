using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using CloudMining.Models.DataWorkers;
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
		}
		#endregion

		#region Properties
		private ObservableCollection<Member> _membersList = new ObservableCollection<Member>(MemberWorker.GetMembers());
		public ObservableCollection<Member> MembersList
		{
			get => _membersList;
			set => Set(ref _membersList, value);
		}
		#endregion

		#region Commands

		#region AddNewMemberCommand
		public ICommand AddNewMemberCommand { get; }
		private bool CanAddNewMemberCommandExecute(object p) => true;
		private void OnAddNewMemberCommandExecuted(object p)
		{
			NewMemberForm newForm = new NewMemberForm();
			newForm.ShowDialog();

			this.MembersList = new ObservableCollection<Member>(MemberWorker.GetMembers());
			MessageBox.Show("Участник создан!");
		}
		#endregion

		#endregion
	}
}
