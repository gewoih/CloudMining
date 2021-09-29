using CloudMining.Infrastructure.Commands;
using System.Windows.Forms;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	internal class MainWindowViewModel : BaseViewModel
	{
		#region Properties
		#endregion

		#region Constructor
		public MainWindowViewModel()
		{
			WindowMenuBarDragCommand = new RelayCommand(OnWindowMenuBarDragCommandExecuted, CanWindowMenuBarDragCommandExecute);
		}
		#endregion

		#region Commands

		#region WindowMenuBarDragCommand
		public ICommand WindowMenuBarDragCommand { get; }
		private bool CanWindowMenuBarDragCommandExecute(object p) => true;
		private void OnWindowMenuBarDragCommandExecuted(object p)
		{
			MessageBox.Show("Перетаскивание");
		}
		#endregion

		#endregion
	}
}
