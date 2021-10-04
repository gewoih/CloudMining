using CloudMining.Interfaces;
using CloudMining.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace CloudMining
{
	internal class MembersList : ICustomList<Member>
	{
		public List<Member> items { get; set; }

		public MembersList()
		{
			this.items = new List<Member>();
		}

		public void LoadList()
		{
			SQL connection = new SQL();

			SqlDataReader reader = connection.Execute("select members.id, member_types_dict.name as role, members.name, join_date, fee from members join member_types_dict ON members.type = member_types_dict.id");
			while (reader.Read())
			{
				items.Add(new Member(Convert.ToInt32(reader["id"]),
									reader["role"].ToString(),
									reader["name"].ToString(),
									Convert.ToDateTime(reader["join_date"]),
									Convert.ToDouble(reader["fee"])));
			}
		}

		public void DrawList(DataGrid dataGrid)
		{
			dataGrid.ItemsSource = this.items;
			dataGrid.AutoGenerateColumns = true;
		}
	}
}
