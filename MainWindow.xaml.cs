using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CloudMining
{
	public partial class MainWindow : Window
	{
		MembersList membersList;

		public MainWindow()
		{
			InitializeComponent();

			membersList = new MembersList();
		}

		private void membersMenu_Selected(object sender, RoutedEventArgs e)
		{
			this.membersList.LoadList();
			this.membersList.DrawList(MainField);
		}
	}
}
