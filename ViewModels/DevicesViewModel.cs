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
		}
		#endregion

		#region Properties
		private ObservableCollection<Device> _devicesList = new ObservableCollection<Device>();
		public ObservableCollection<Device> DevicesList
		{
			get => _devicesList;
			set => Set(ref _devicesList, value);
		}

		private int _id;
		public int Id
		{
			get => _id;
			set => Set(ref _id, value);
		}

		private string _workerName;
		public string WorkerName
		{
			get => _workerName;
			set => Set(ref _workerName, value);
		}

		private DateTime _purchaseDate;
		public DateTime PurchaseDate
		{
			get => _purchaseDate;
			set => Set(ref _purchaseDate, value);
		}

		private double _hashrate;
		public double Hashrate
		{
			get => _hashrate;
			set => Set(ref _hashrate, value);
		}

		private string _currency;
		public string Currency
		{
			get => _currency;
			set => Set(ref _currency, value);
		}

		private int _consumption;
		public int Consumption
		{
			get => _consumption;
			set => Set(ref _consumption, value);
		}
		#endregion

		#region Commands
		public ICommand LoadDevicesCommand { get; }
		private bool CanLoadDevicesCommandExecute(object p) => true;
		private void OnLoadDevicesCommandExecuted(object p)
		{
			SQL connection = new SQL();

			SqlDataReader reader = connection.Execute("select devices.id, worker_name, purchase_date, hashrate, currency_dict.short_name as currency, consumption from devices join currency_dict ON devices.currency_id = currency_dict.id");
			while (reader.Read())
			{
				this.DevicesList.Add(new Device(Convert.ToInt32(reader["id"]),
												reader["worker_name"].ToString(),
												Convert.ToDateTime(reader["purchase_date"]),
												Convert.ToDouble(reader["hashrate"]),
												reader["currency"].ToString(),
												Convert.ToInt32(reader["consumption"])));
			}
		}
		#endregion
	}
}
