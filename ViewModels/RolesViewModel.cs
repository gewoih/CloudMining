using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using CloudMining.Models.DataWorkers;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CloudMining.ViewModels
{
	public class RolesViewModel : BaseViewModel
	{
		#region Constructor
		public RolesViewModel()
		{
			dataWorker = new RolesDataWorker();
			Roles = new ObservableCollection<Role>(dataWorker.GetAll());
		}
		#endregion

		#region Properties
		private readonly RolesDataWorker dataWorker;

		private ObservableCollection<Role> _Roles;
		public ObservableCollection<Role> Roles
		{
			get => _Roles;
			set => Set(ref _Roles, value);
		}
		#endregion
	}
}
