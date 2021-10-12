using CloudMining.Infrastructure.Commands;
using System;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		#region Properties
		private int _menuIndex = 0;
		public int MenuIndex
		{
			get => _menuIndex;
			set => Set(ref _menuIndex, value);
		}

		private object _mainContentControl;
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
					MainContentControl = new MembersViewModel();
					break;
				case 2:
					MainContentControl = new DevicesViewModel();
					break;
				case 3:
					MainContentControl = new DepositsViewModel();
					break;
			}
		}
		#endregion

		#endregion
	}
}