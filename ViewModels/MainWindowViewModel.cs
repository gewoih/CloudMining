using CloudMining.Infrastructure.Commands;
using System;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		#region Properties
		private int _menuIndex;
		public int MenuIndex
		{
			get => _menuIndex;
			set => Set(ref _menuIndex, value);
		}

		private object _mainContentControl = new MembersViewModel();
		public object MainContentControl
		{
			get => _mainContentControl;
			set => Set(ref _mainContentControl, value);
		}
		#endregion

		#region Constructor
		public MainWindowViewModel()
		{
			ChangeMenuIndexCommand = new RelayCommand(OnChangeMenuIndexCommandExecuted, CanChangeMenuIndexCommandExecute);
		}
		#endregion

		#region Commands

		#region ChangeMenuIndex
		public ICommand ChangeMenuIndexCommand { get; }
		private bool CanChangeMenuIndexCommandExecute(object p) => true;
		private void OnChangeMenuIndexCommandExecuted(object p)
		{
			MenuIndex = Convert.ToInt32(p);

			switch (MenuIndex)
			{
				case 1:
					//MainContentControl = new StatisticsViewModel();
					break;
				case 2:
					if (MainContentControl is not MembersViewModel)
						MainContentControl = new MembersViewModel();
					break;
				case 3:
					if (MainContentControl is not PayoutsViewModel)
						MainContentControl = new PayoutsViewModel();
					break;
				case 4:
					if (MainContentControl is not DepositsViewModel)
						MainContentControl = new DepositsViewModel();
					break;
				case 5:
					if (MainContentControl is not PurchasesViewModel)
						MainContentControl = new PurchasesViewModel();
					break;
				case 6:
					if (MainContentControl is not DevicesViewModel)
						MainContentControl = new DevicesViewModel();
					break;
				case 7:
					if (MainContentControl is not ElectricityPaymentsViewModel)
						MainContentControl = new ElectricityPaymentsViewModel();
					break;
			}
		}
		#endregion

		#endregion
	}
}