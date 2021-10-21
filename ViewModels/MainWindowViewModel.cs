using CloudMining.Infrastructure.Commands;
using CloudMining.Views;
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

		private object _mainContentControl = new StatisticsView();
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
					if (MainContentControl is not StatisticsView)
						MainContentControl = new StatisticsView();
					break;
				case 2:
					if (MainContentControl is not MembersView)
						MainContentControl = new MembersView();
					break;
				case 3:
					if (MainContentControl is not PayoutsView)
						MainContentControl = new PayoutsView();
					break;
				case 4:
					if (MainContentControl is not DepositsView)
						MainContentControl = new DepositsView();
					break;
				case 5:
					if (MainContentControl is not PurchasesView)
						MainContentControl = new PurchasesView();
					break;
				case 6:
					if (MainContentControl is not DevicesView)
						MainContentControl = new DevicesView();
					break;
				case 7:
					if (MainContentControl is not ElectricityPaymentsView)
						MainContentControl = new ElectricityPaymentsView();
					break;
			}
		}
		#endregion

		#endregion
	}
}