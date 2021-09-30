using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	internal class MembersViewModel : BaseViewModel
	{
		#region Constructor
		public MembersViewModel()
		{
			LoadMembersCommand = new RelayCommand(OnLoadMembersCommandExecuted, CanLoadMembersCommandExecute);
		}
		#endregion

		#region Commands

		#region LoadMembersCommand
		public ICommand LoadMembersCommand { get; }
		private bool CanLoadMembersCommandExecute(object p) => true;
		private void OnLoadMembersCommandExecuted(object p)
		{
			SQL connection = new SQL();

			SqlDataReader reader = connection.Execute("select members.id, members_types_dict.name as role, members.name, join_date, fee from members join members_types_dict ON members.type = members_types_dict.id");
			while (reader.Read())
			{
				this.MembersList.Add(new Member(Convert.ToInt32(reader["id"]),
												reader["role"].ToString(),
												reader["name"].ToString(),
												Convert.ToDateTime(reader["join_date"]),
												Convert.ToDouble(reader["fee"])));
			}
		}
		#endregion

		#endregion

		#region Properties
		private ObservableCollection<Member> _membersList = new ObservableCollection<Member>();
		public ObservableCollection<Member> MembersList
		{
			get => _membersList;
			set => Set(ref _membersList, value);
		}

		private int _id;
		public int Id
		{
			get => _id;
			set => Set(ref _id, value);
		}

		private string _role;
		public string Role
		{
			get => _role;
			set => Set(ref _role, value);
		}

		private string _name;
		public string Name
		{
			get => _name;
			set => Set(ref _name, value);
		}

		private DateTime _joinDate;
		public DateTime JoinDate
		{
			get => _joinDate;
			set => Set(ref _joinDate, value);
		}

		private double _fee;
		public double Fee
		{
			get => _fee;
			set => Set(ref _fee, value);
		}
		#endregion
	}
}
