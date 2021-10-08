using CloudMining.Infrastructure.Commands;
using CloudMining.Models;
using CloudMining.Views.Windows;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using CloudMining.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CloudMining.ViewModels
{
	internal class MembersViewModel : BaseViewModel
	{
		#region Constructor
		public MembersViewModel()
		{
			AddNewMemberCommand = new RelayCommand(OnAddNewMemberCommandExecuted, CanAddNewMemberCommandExecute);
			DeleteMemberCommand = new RelayCommand(OnDeleteMemberCommandExecuted, CanDeleteMemberCommandExecute);
		}
		#endregion

		#region Properties
		//Список моделей Member для их отображения в MembersView
		private ObservableCollection<Member>  _membersList;
		public ObservableCollection<Member> MembersList
		{
			get
			{
				if (_membersList == null)
					this.LoadMembersAsync();
				return _membersList;
			}
		}


		//Выделенный пользователем Member в MembersView
		private Member _selectedMember;
		public Member SelectedMember
		{
			get => _selectedMember;
			set => Set(ref _selectedMember, value);
		}
		#endregion





		#region Database Methods

		//Создание нового Member
		private Task CreateMemberAsync(string name, Role role, string joinDate)
		{
			return Task.Run(() =>
			{
				using (Data.ApplicationContext db = new Data.ApplicationContext())
				{
					Member newMember = new Member
					{
						Name = name,
						RoleId = role.Id,
						JoinDate = joinDate
					};
					db.Members.Add(newMember);
					db.SaveChanges();
				}
			});
		}

		//Загрузка существующих в базе Member
		private Task LoadMembersAsync()
		{
			return Task.Run(() =>
			{
				using (Data.ApplicationContext db = new Data.ApplicationContext())
				{
					this._membersList = new ObservableCollection<Member>(db.Members.Include(m => m.Role).Include(m => m.Deposits));
				}
			});
		}

		//Удаление Member
		private Task DeleteMemberAsync(Member member)
		{
			return Task.Run(() =>
			{
				using (Data.ApplicationContext db = new Data.ApplicationContext())
				{
					db.Members.Remove(member);
					db.SaveChanges();
				}
			});
		}
		#endregion

		#region Commands
		//Команда для вызова формы NewMemberForm
		#region AddNewMemberCommand
		public ICommand AddNewMemberCommand { get; }
		private bool CanAddNewMemberCommandExecute(object p) => true;
		private void OnAddNewMemberCommandExecuted(object p)
		{
			NewMemberForm newForm = new NewMemberForm(MembersViewModel mVM);
			newForm.ShowDialog();

			MessageBox.Show("Участник создан!");
		}
		#endregion

		//Удаление выделенного Member
		#region DeleteMemberCommand
		public ICommand DeleteMemberCommand { get; }
		private bool CanDeleteMemberCommandExecute(object p) => true;
		private void OnDeleteMemberCommandExecuted(object p)
		{
			//Диалоговое окно для подтверждения удаления Member
			DialogResult dialogResult = MessageBox.Show($"Вы действительно хотите удалить участника {SelectedMember.Name}[{SelectedMember.Id}]?", 
														"Подтверждение удаления участника", 
														MessageBoxButtons.YesNo);

			if (dialogResult == DialogResult.Yes)
			{
				this.DeleteMemberAsync(SelectedMember);
				MessageBox.Show("Участник удален.");
			}
		}
		#endregion

		#endregion
	}
}
