using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using CloudMining.Views.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Forms;
using CloudMining.Models.DataWorkers;

namespace CloudMining.ViewModels
{
	public class MembersViewModel : BaseViewModel
	{
		#region Constructor
		public MembersViewModel()
		{
			dataWorker = new MembersDataWorker();
			Members = new ObservableCollection<Member>(dataWorker.GetAll());

			AddNewMemberCommand = new RelayCommand(OnAddNewMemberCommandExecuted, CanAddNewMemberCommandExecute);
			RemoveMemberCommand = new RelayCommand(OnRemoveMemberCommandExecuted, CanRemoveMemberCommandExecute);
		}
		#endregion

		#region Properties
		private readonly MembersDataWorker dataWorker;

		//Список моделей Member для их отображения в MembersView
		private ObservableCollection<Member>  _Members;
		public ObservableCollection<Member> Members
		{
			get => _Members;
			set => Set(ref _Members, value);
		}

		//Выделенный пользователем Member в MembersView
		private Member _SelectedMember;
		public Member SelectedMember
		{
			get => _SelectedMember;
			set => Set(ref _SelectedMember, value);
		}
		#endregion

		#region Command AddNewMemberCommand
		public ICommand AddNewMemberCommand { get; }
		private bool CanAddNewMemberCommandExecute(object p) => true;
		private void OnAddNewMemberCommandExecuted(object p)
		{
			var newMember = new Member();
			NewMemberForm newForm = new NewMemberForm(dataWorker, newMember);

			if (newForm.ShowDialog() == true)
			{
				dataWorker.Create(newMember);
				_Members.Add(newMember);
				SelectedMember = newMember;
			}
		}
		#endregion

		#region Command RemoveMemberCommand
		public ICommand RemoveMemberCommand { get; }
		private bool CanRemoveMemberCommandExecute(object p) => SelectedMember != null;
		private void OnRemoveMemberCommandExecuted(object p)
		{
			DialogResult dialogResult = MessageBox.Show($"Вы действительно хотите удалить участника {SelectedMember.Name} [{SelectedMember.Id}]?",
														"Подтверждение удаления участника",
														MessageBoxButtons.YesNo);

			if (dialogResult == DialogResult.Yes)
			{
				dataWorker.Delete(SelectedMember.Id);
				Members.Remove(SelectedMember);

				MessageBox.Show("Участник удален.");
			}
		}
		#endregion
	}
}