using CloudMining.Models;
using System.Windows;

namespace CloudMining.Views.Windows
{
	/// <summary>
	/// Логика взаимодействия для NewMemberForm.xaml
	/// </summary>
	public partial class NewMemberForm : Window
	{
		//private Dictionary<string, int> membersTypes = new Dictionary<string, int>();

		public NewMemberForm()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//Подгрузка ComboBox
		}

		private void AddMemberButton_Click(object sender, RoutedEventArgs e)
		{
			DataWorker dataWorker = new DataWorker();
		}
	}
}
