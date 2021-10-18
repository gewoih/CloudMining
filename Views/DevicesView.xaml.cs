using System.ComponentModel;
using System.Windows.Controls;

namespace CloudMining.Views
{
	/// <summary>
	/// Логика взаимодействия для DevicesView.xaml
	/// </summary>
	public partial class DevicesView : UserControl
	{
		public DevicesView()
		{
			InitializeComponent();

			this.dataGrid.Items.SortDescriptions.Add(new SortDescription("PurchaseDate", ListSortDirection.Descending));
		}
	}
}
