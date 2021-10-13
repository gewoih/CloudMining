using CloudMining.DataContext;
using CloudMining.Models;
using CloudMining.Models.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CloudMining.Views.Windows
{
	/// <summary>
	/// Логика взаимодействия для NewPurchaseForm.xaml
	/// </summary>
	public partial class NewPurchaseForm : Window
	{
		private readonly Purchase _NewPurchase;

		public NewPurchaseForm(Purchase NewPurchase)
		{
			InitializeComponent();

			this._NewPurchase = NewPurchase;
		}

		private void AddPurchaseButton_Click(object sender, RoutedEventArgs e)
		{
			string newPurchaseSubject = SubjectTextBox.Text;
			double newPurchaseAmount = Convert.ToDouble(AmountTextBox.Text);
			string newPurchaseDate = PurchaseDatePicker.Text;

			if (!newPurchaseSubject.Equals(null) && newPurchaseAmount > 0
				&& DateTime.Parse(newPurchaseDate) <= DateTime.Now)
			{
				this._NewPurchase.Subject = newPurchaseSubject;
				this._NewPurchase.Amount = newPurchaseAmount;
				this._NewPurchase.Date = newPurchaseDate;

				this.DialogResult = true;
				MessageBox.Show("Покупка добавлена!");
			}
			else
				MessageBox.Show("Введите корректные данные!");
		}
	}
}
