using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	internal class DevicesViewModel : BaseViewModel
	{
		#region Constructor
		public DevicesViewModel()
		{
			LoadDevicesCommand = new RelayCommand(OnLoadDevicesCommandExecuted, CanLoadDevicesCommandExecute);
			LoadDevicesCommand.Execute(null);
		}
		#endregion

		#region Properties
		private ObservableCollection<Device> _devicesList = new ObservableCollection<Device>();
		public ObservableCollection<Device> DevicesList
		{
			get => _devicesList;
			set => Set(ref _devicesList, value);
		}
		#endregion

		#region Commands
		public ICommand LoadDevicesCommand { get; }
		private bool CanLoadDevicesCommandExecute(object p) => true;
		private void OnLoadDevicesCommandExecuted(object p)
		{
		}
		#endregion
	}
}
