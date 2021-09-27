using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace CloudMining.ViewModels
{
	public class MembersList : IList<Member>
	{
		public List<Member> items { get; set; }

		public MembersList()
		{
			this.items = new List<Member>();
		}

		public void LoadList()
		{
			SQL connection = new SQL();

			SqlDataReader reader = connection.Execute("select members.id, members_types_dict.name as role, members.name, join_date, fee from members join members_types_dict ON members.type = members_types_dict.id");
			while (reader.Read())
			{
				items.Add(new Member(Convert.ToInt32(reader["id"]), 
									reader["role"].ToString(), 
									reader["name"].ToString(), 
									Convert.ToDateTime(reader["join_date"]),
									Convert.ToDouble(reader["fee"])));
			}
		}

		public void DrawList(StackPanel uIElement)
		{
			ListView MainListView = new ListView();
			GenerateFontSettings(MainListView);

			MainListView.View = GenerateGridView();
			MainListView.ItemsSource = GenerateDataTable().DefaultView;

			MainListView.ContextMenu = GenerateContextMenu();

			uIElement.Children.Clear();
			uIElement.Children.Add(MainListView);
		}

		public void GenerateFontSettings(ListView listView)
		{
			listView.Foreground = new SolidColorBrush(Colors.White);
			listView.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#567CC7"));
			listView.FontSize = 18;
		}

		public GridView GenerateGridView()
		{
			GridView view = new GridView();

			view.Columns.Add(new GridViewColumn() { Header = "id", DisplayMemberBinding = new Binding("id") });
			view.Columns.Add(new GridViewColumn() { Header = "Роль", DisplayMemberBinding = new Binding("role") });
			view.Columns.Add(new GridViewColumn() { Header = "Имя", DisplayMemberBinding = new Binding("name") });
			view.Columns.Add(new GridViewColumn() { Header = "Присоединился", DisplayMemberBinding = new Binding("joinDate") });
			view.Columns.Add(new GridViewColumn() { Header = "Комиссия", DisplayMemberBinding = new Binding("fee") });

			return view;
		}

		public DataTable GenerateDataTable()
		{
			DataTable data = new DataTable();
			data.Columns.Add("id");
			data.Columns.Add("role");
			data.Columns.Add("name");
			data.Columns.Add("joinDate");
			data.Columns.Add("fee");

			foreach (var item in this.items)
			{
				DataRow row = data.NewRow();
				row["id"] = item.id;
				row["role"] = item.Role;
				row["name"] = item.name;
				row["joinDate"] = item.joinDate.ToShortDateString();
				row["fee"] = item.fee + "%";

				data.Rows.Add(row);
			}

			return data;
		}

		public ContextMenu GenerateContextMenu()
		{
			ContextMenu menu = new ContextMenu();
			MenuItem miAddNewMember = new MenuItem();
			MenuItem miOpenMemberInfo = new MenuItem();

			miAddNewMember.Header = "Добавить нового участника";
			miOpenMemberInfo.Header = "Просмотр информации об участнике";

			miAddNewMember.PreviewMouseDown += miAddNewMember_Click;
			miOpenMemberInfo.PreviewMouseDown += miOpenMemberInfo_Click;

			menu.Items.Add(miAddNewMember);
			menu.Items.Add(miOpenMemberInfo);

			return menu;
		}

		private void miAddNewMember_Click(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("Добавили");
		}

		private void miOpenMemberInfo_Click(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("Открыли");
		}
	}
}
