using CloudMining.DataContext;
using CloudMining.Models;
using CloudMining.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CloudMining.Views.Windows
{
	/// <summary>
	/// Логика взаимодействия для NewDeviceForm.xaml
	/// </summary>
	public partial class NewDeviceForm : Window
	{
		private readonly Device newDevice;
		private readonly List<Currency> _Currencies;

		public NewDeviceForm(Device newDevice)
		{
			InitializeComponent();

			this.newDevice = newDevice;
			this._Currencies = new CurrenciesRepository(new BaseDataContext()).GetAll().ToList();

			CurrenciesComboBox.ItemsSource = _Currencies;
			CurrenciesComboBox.DisplayMemberPath = "Name";
		}

		private void AddDeviceButton_Click(object sender, RoutedEventArgs e)
		{
			string newDeviceName = NameTextBox.Text;
			Currency newDeviceCurrency = _Currencies.FirstOrDefault(c => c.Name == CurrenciesComboBox.Text);
			double newDeviceHashrate = Convert.ToDouble(HashrateTextBox.Text);
			int newDeviceConsumption = Convert.ToInt32(ConsumptionTextBox.Text);
			string newDevicePurchaseDate = PurchaseDatePicker.Text;

			if (!newDeviceName.Equals(String.Empty) && !newDeviceCurrency.Equals(null)
				&& newDeviceHashrate > 0 && newDeviceConsumption > 0 
				&& DateTime.Parse(newDevicePurchaseDate) <= DateTime.Now)
			{
				this.newDevice.Name = newDeviceName;
				this.newDevice.Currency = newDeviceCurrency;
				this.newDevice.Hashrate = newDeviceHashrate;
				this.newDevice.Consumption = newDeviceConsumption;
				this.newDevice.PurchaseDate = newDevicePurchaseDate;

				this.DialogResult = true;
				MessageBox.Show("Устройство создано!");
			}
			else
				MessageBox.Show("Введите корректные данные!");
		}
	}
}
