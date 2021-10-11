﻿using CloudMining.DataContext;
using CloudMining.Models;
using CloudMining.Models.Repositories.Base;
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
		private readonly List<Role> _Roles;

		public NewMemberForm(Member newMember)
		{
			InitializeComponent();

			this._Roles = new RolesRepository(new BaseDataContext()).GetAll().ToList();
			this.NewMember = newMember;

			this.RolesComboBox.ItemsSource = _Roles;
			this.RolesComboBox.DisplayMemberPath = "Name";
		}

		private void AddMemberButton_Click(object sender, RoutedEventArgs e)
		{
			string newMemberName = NameTextBox.Text;
			Role newMemberRole = _Roles.FirstOrDefault(r => r.Name == RolesComboBox.Text);
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