using CloudMining.DataContext;
using CloudMining.Models.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMining.Models.Repositories
{
	public class ElectricityPaymentsRepository : BaseRepository<ElectricityPayment>
	{
		public ElectricityPaymentsRepository(BaseDataContext dbContext) : base(dbContext) { }

		public override ElectricityPayment Create(ElectricityPayment newPayment)
		{
			SplitPayment(newPayment);

			return base.Create(newPayment);
		}

		private void SplitPayment(ElectricityPayment newPayment)
		{
			List<Member> Members = new MembersRepository(new BaseDataContext()).GetAll().ToList();
			IRepository<ElectricityPaymentShare> ElectricityPaymentSharesRepository = new ElectricityPaymentSharesRepository(new BaseDataContext());

			foreach (var member in Members)
			{
				ElectricityPaymentSharesRepository.Create(
				new ElectricityPaymentShare
				{
					BaseEntity = newPayment,
					Member = member,
					Percent = member.Share,
					Amount = Math.Round(newPayment.Amount * member.Share / 100, 0, MidpointRounding.AwayFromZero),
					IsDone = false
				}) ;
			}
		}
	}
}
