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
			SQL connection = new SQL();
			this.MembersList.Clear();

			SqlDataReader reader = connection.Execute("select members.id, members_types_dict.name as role, members.name, join_date, ISNULL(s.res, 0) as invested from members join members_types_dict ON members.type=members_types_dict.id LEFT join (select sum(o.amount) as res, o.from_member_id from operations as o group by o.from_member_id) as s ON s.from_member_id = members.id;");
			while (reader.Read())
			{
				this.MembersList.Add(new Member(Convert.ToInt32(reader["id"]),
												reader["role"].ToString(),
												reader["name"].ToString(),
												String.Format("{0:dd.MM.yyyy}", reader["join_date"]),
												Convert.ToDouble(reader["invested"])));
			}
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
