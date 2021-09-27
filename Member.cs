using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CloudMining.ViewModels
{
	public class Member : MainViewModel
	{
		private int id;
		private string role;
		private string name;
		private DateTime joinDate;
		private double fee;

		public int Id
		{
			get { return id; }
			set
			{
				id = value;
				OnPropertyChanged("Id");
			}
		}

		public string Role
		{
			get { return role; }
			set
			{
				role = value;
				OnPropertyChanged("Role");
			}
		}

		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}

		public DateTime JoinDate
		{
			get { return joinDate; }
			set
			{
				joinDate = value;
				OnPropertyChanged("JoinDate");
			}
		}

		public double Fee
		{
			get { return fee; }
			set
			{
				Fee = value;
				OnPropertyChanged("Fee");
			}
		}
	}
}
