using CloudMining.Models;
using CloudMining.Models.DataWorkers;
using CloudMining.Models.DataWorkers.Base;
using CloudMining.ViewModels;
using System;
using System.Collections;
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
		private Member NewMember;
		private readonly RolesViewModel RolesVM;

		public NewMemberForm(MembersDataWorker dataWorker, Member newMember)
		{
			InitializeComponent();

			this.NewMember = newMember;
			this.RolesVM = new RolesViewModel();
		}

		private void AddMemberButton_Click(object sender, RoutedEventArgs e)
		{
			string newMemberName = NameTextBox.Text;
			Role newMemberRole = RolesVM.Roles.FirstOrDefault(r => r.Name == RolesComboBox.Text);
			string newMemberJoinDate = JoinDatePicker.Text;

			if (!newMemberName.Equals(String.Empty) && !newMemberRole.Equals(null)
				&& !newMemberJoinDate.Equals(String.Empty) && DateTime.Parse(newMemberJoinDate) <= DateTime.Now)
			{
				this.NewMember.Name = newMemberName;
				this.NewMember.Role = newMemberRole;
				this.NewMember.JoinDate = newMemberJoinDate;

				this.DialogResult = true;
				MessageBox.Show("Участник создан!");
			}
			else
				MessageBox.Show("Введите корректные данные!");
		}
	}
}
