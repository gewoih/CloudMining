using CloudMining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CloudMining.Views.Windows
{
	/// <summary>
	/// Логика взаимодействия для NewMemberForm.xaml
	/// </summary>
	public partial class NewMemberForm : Window
	{
		public NewMemberForm()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			MemberTypeCB.ItemsSource = DataWorker.GetRoles().Select(r => r.name);
		}

		private void AddMemberButton_Click(object sender, RoutedEventArgs e)
		{
			if (!MemberNameTB.Equals(String.Empty) && !MemberTypeCB.SelectedIndex.Equals(-1) && MemberJoinDP.SelectedDate <= DateTime.Now)
			{
				DataWorker.CreateMember(new Member(DataWorker.GetRoles()[MemberTypeCB.SelectedIndex].id, MemberNameTB.Text, MemberJoinDP.Text));
				this.DialogResult = true;
				this.Close();
			}
			else
				MessageBox.Show("Введите корректные данные!");
		}
	}
}
