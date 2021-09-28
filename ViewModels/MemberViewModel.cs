using CloudMining.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CloudMining.ViewModels
{
	internal class MemberViewModel : BaseViewModel
	{
		private Member member;

		public MemberViewModel(Member member)
		{
			this.member = member;
		}

		public int Id
		{
			get => this.member.id;
			set
			{
				this.member.id = value;
				OnPropertyChanged("Id");
			}
		}

		public string Role
		{
			get => this.member.role;
			set
			{
				this.member.role = value;
				OnPropertyChanged("Role");
			}
		}

		public string Name
		{
			get => this.member.name;
			set
			{
				this.member.name = value;
				OnPropertyChanged("Name");
			}
		}

		public DateTime JoinDate
		{
			get => this.member.joinDate;
			set
			{
				this.member.joinDate = value;
				OnPropertyChanged("JoinDate");
			}
		}

		public double Fee
		{
			get => this.member.fee;
			set
			{
				this.member.fee = value;
				OnPropertyChanged("Fee");
			}
		}
	}
}
