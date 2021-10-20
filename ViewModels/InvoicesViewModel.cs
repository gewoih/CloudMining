using CloudMining.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	public class InvoicesViewModel : BaseViewModel
	{
		#region Constructor
		public InvoicesViewModel()
		{
			ChangeMenuIndexCommand = new RelayCommand(OnChangeMenuIndexCommandExecuted, CanChangeMenuIndexCommandExecute);
		}
		#endregion

		#region Properties
		private int _menuIndex;
		public int MenuIndex
		{
			get => _menuIndex;
			set => Set(ref _menuIndex, value);
		}

		private object _mainContentControl = new PayoutSharesViewModel();
		public object MainContentControl
		{
			get => _mainContentControl;
			set => Set(ref _mainContentControl, value);
		}
		#endregion

		#region Commands
		public ICommand ChangeMenuIndexCommand { get; }
		private bool CanChangeMenuIndexCommandExecute(object p) => true;
		private void OnChangeMenuIndexCommandExecuted(object p)
		{
			MenuIndex = Convert.ToInt32(p);

			switch (MenuIndex)
			{
				case 1:
					if (MainContentControl is not PayoutSharesViewModel)
						MainContentControl = new PayoutSharesViewModel();
					break;
				case 2:
					if (MainContentControl is not MembersViewModel)
						MainContentControl = new MembersViewModel();
					break;
				case 3:
					if (MainContentControl is not ElectricityPaymentSharesViewModel)
						MainContentControl = new ElectricityPaymentSharesViewModel();
					break;
			}
		}
		#endregion
	}
}
