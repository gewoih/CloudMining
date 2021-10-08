using CloudMining.Models;
using CloudMining.Models.DataWorkers;
using System.Collections.ObjectModel;

namespace CloudMining.ViewModels
{
	internal class DevicesViewModel : BaseViewModel
	{
		#region Properties
		private ObservableCollection<Device> _devicesList = new ObservableCollection<Device>(DeviceWorker.GetDevices());
		public ObservableCollection<Device> DevicesList
		{
			get => _devicesList;
			set => Set(ref _devicesList, value);
		}
		#endregion
	}
}
