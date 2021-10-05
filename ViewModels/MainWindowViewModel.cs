using CloudMining.Infrastructure.Commands;
using CloudMining.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	internal class MainWindowViewModel : BaseViewModel
	{
		#region Properties
		private MembersViewModel _membersVM = new MembersViewModel();
		public MembersViewModel MembersVM
		{
			get => _membersVM;
			set => Set(ref _membersVM, value);
		}

		private DevicesViewModel _devicesVM = new DevicesViewModel();
		public DevicesViewModel DevicesVM
		{
			get => _devicesVM;
			set => Set(ref _devicesVM, value);
		}

		private DepositsViewModel _depositsVM = new DepositsViewModel();
		public DepositsViewModel DepositsVM
		{
			get => _depositsVM;
			set => Set(ref _depositsVM, value);
		}

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
			CloseWindowCommand = new RelayCommand(OnCloseWindowCommandExecuted, CanCloseWindowCommandExecute);
		}
		#endregion

		#region Commands

		#region CloseWindow
		public ICommand CloseWindowCommand { get; }
		private bool CanCloseWindowCommandExecute(object parameter) => true;
		private void OnCloseWindowCommandExecuted(object parameter) => Application.Current.Shutdown();
		#endregion

		#region ChangeMenuIndex
		public ICommand ChangeMenuIndexCommand { get; }
		private bool CanChangeMenuIndexCommandExecute(object p) => true;
		private void OnChangeMenuIndexCommandExecuted(object p)
		{
			MenuIndex = Convert.ToInt32(p);

			switch (MenuIndex)
			{
				case 1:
					MainContentControl = MembersVM;
					break;
				case 2:
					MainContentControl = DevicesVM;
					break;
				case 3:
					MainContentControl = DepositsVM;
					break;
			}
		}
		#endregion

		#endregion
	}
}