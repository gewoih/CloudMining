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

		private int _menuIndex = 0;
		public int MenuIndex
		{
			get => _menuIndex;
			set
			{
				Set(ref _menuIndex, value);

				switch (MenuIndex)
				{
					case 1:
						MembersVM.LoadMembersCommand.Execute(null);
						MainPanelView = MembersVM;
						break;
					case 2:
						break;
				}
			}
		}

		private object _mainPanelView;
		public object MainPanelView
		{
			get => _mainPanelView;
			set => Set(ref _mainPanelView, value);
		}
		#endregion

		#region Constructor
		public MainWindowViewModel()
		{
			ChangeMenuIndexCommand = new RelayCommand(OnChangeMenuIndexCommandExecuted, CanChangeMenuIndexCommandExecute);
			CloseWindowCommand = new RelayCommand(OnCloseWindowCommandExecuted, CanCloseWindowCommandExecute);
		}
		#endregion

		#region Methods



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
		}
		#endregion

		#endregion
	}
}