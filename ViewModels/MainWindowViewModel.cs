using CloudMining.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CloudMining.ViewModels
{
	class MainWindowViewModel : BaseViewModel
	{
		public ObservableCollection<MemberViewModel> MembersList { get; set; }

		public MainWindowViewModel(List<Member> members)
		{
			this.MembersList = new ObservableCollection<MemberViewModel>(members.Select(m => new MemberViewModel(m)));
		}
	}
}
