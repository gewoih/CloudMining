using System.Collections.Generic;
using System.Windows.Controls;

namespace CloudMining.Interfaces
{
	internal interface ICustomList<T>
	{
		public List<T> items { get; set; }

		public void LoadList();
		public void DrawList(DataGrid dataGrid);
	}
}
