using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
	/// Логика взаимодействия для NewMemberForm.xaml
	/// </summary>
	public partial class NewMemberForm : Window
	{
		private Dictionary<string, int> membersTypes = new Dictionary<string, int>();

		public NewMemberForm()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			SQL connection = new SQL();

			SqlDataReader reader = connection.Execute("select id, name from members_types_dict");
			while (reader.Read())
			{
				this.membersTypes.Add(reader["name"].ToString(), Convert.ToInt32(reader["id"]));
			}
			MemberTypeCB.ItemsSource = this.membersTypes.Keys;
		}

		private void AddMemberButton_Click(object sender, RoutedEventArgs e)
		{
			SQL connection = new SQL();

			if (!MemberNameTB.Equals(String.Empty) && !MemberTypeCB.SelectedIndex.Equals(-1) && MemberJoinDP.SelectedDate <= DateTime.Now)
				connection.Execute("insert into members values(" + membersTypes[MemberTypeCB.Text] + ", '" + MemberNameTB.Text + "', " + "'" + MemberJoinDP.SelectedDate + "')");
			else
				MessageBox.Show("Введите корректные данные!");
		}
	}
}
