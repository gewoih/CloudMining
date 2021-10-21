using CloudMining.DataContext;
using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using CloudMining.Repositories;
using CloudMining.Repositories.Base;
using CloudMining.Views.Windows;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	public class DevicesViewModel : BaseViewModel
	{
		#region Constructor
		public DevicesViewModel()
		{
			this._DevicesRepository = new DevicesRepository(new BaseDataContext());
			this.Devices = new ObservableCollection<Device>(_DevicesRepository.GetAll());

			AddNewDeviceCommand = new RelayCommand(OnAddNewDeviceCommandExecuted, CanAddNewDeviceCommandExecute);
			RemoveDeviceCommand = new RelayCommand(OnRemoveDeviceCommandExecuted, CanRemoveDeviceCommandExecute);
		}
		#endregion

		#region Properties
		private readonly IRepository<Device> _DevicesRepository;

		private ObservableCollection<Device> _Devices;
		public ObservableCollection<Device> Devices
		{
			get => _Devices;
			set => Set(ref _Devices, value);
		}

		private Device _SelectedDevice;
		public Device SelectedDevice
		{
			get => _SelectedDevice;
			set => Set(ref _SelectedDevice, value);
		}
		#endregion

		#region Commands
		#region Command AddNewDeviceCommand
		public ICommand AddNewDeviceCommand { get; }
		private bool CanAddNewDeviceCommandExecute(object p) => true;
		private void OnAddNewDeviceCommandExecuted(object p)
		{
			var NewDevice = new Device();
			NewDeviceForm newForm = new NewDeviceForm(NewDevice);

			if (newForm.ShowDialog() == true)
			{
				this._DevicesRepository.Create(NewDevice);
				_Devices.Add(NewDevice);
				SelectedDevice = NewDevice;
			}
		}
		#endregion

		#region Command RemoveDeviceCommand
		public ICommand RemoveDeviceCommand { get; }
		private bool CanRemoveDeviceCommandExecute(object p) => SelectedDevice != null;
		private void OnRemoveDeviceCommandExecuted(object p)
		{
			DialogResult dialogResult = MessageBox.Show($"Вы действительно хотите удалить устройство {SelectedDevice.Name} [{SelectedDevice.Id}]?",
														"Подтверждение удаления устройства",
														MessageBoxButtons.YesNo);

			if (dialogResult == DialogResult.Yes)
			{
				this._DevicesRepository.Delete(SelectedDevice.Id);
				Devices.Remove(SelectedDevice);

				MessageBox.Show("Устройство удалено.");
			}
		}
		#endregion
		#endregion
	}
}
