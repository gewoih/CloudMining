using CloudMining.Infrastructure.Commands;
using System.Windows;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	internal class MainWindowViewModel : BaseViewModel
	{
		#region Properties
		private object _currentView;
		public object CurrentView
		{
			get => _currentView;
			set => Set(ref _currentView, value);
		}
		#endregion

		#region Constructor
		public MainWindowViewModel()
		{
			CloseWindowCommand = new RelayCommand(OnCloseWindowCommandExecuted, CanCloseWindowCommandExecute);
		}
		#endregion

		#region Commands

		#region CloseWindowCommand
		public ICommand CloseWindowCommand { get; }
		private bool CanCloseWindowCommandExecute(object parameter) => true;
		private void OnCloseWindowCommandExecuted(object parameter) => Application.Current.Shutdown();
		#endregion

		#endregion
	}
}