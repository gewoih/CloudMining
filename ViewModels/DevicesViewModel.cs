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
		#region Properties
		private ObservableCollection<Device> _devicesList = new ObservableCollection<Device>(DataWorker.GetDevices());
		public ObservableCollection<Device> DevicesList
		{
			get => _devicesList;
			set => Set(ref _devicesList, value);
		}
		#endregion
	}
}
