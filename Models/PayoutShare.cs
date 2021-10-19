using CloudMining.Models.Base;

namespace CloudMining.Models
{
	public class PayoutShare : Entity
	{
		private Payout _Payout;
		public Payout Payout
		{
			get => _Payout;
			set => Set(ref _Payout, value);
		}

		private Member _Member;
		public Member Member
		{
			get => _Member;
			set => Set(ref _Member, value);
		}

		private double _Percent;
		public double Percent
		{
			get => _Percent;
			set => Set(ref _Percent, value);
		}

		private double _Amount;
		public double Amount
		{
			get => _Amount;
			set => Set(ref _Amount, value);
		}

		private bool _IsDone;
		public bool IsDone
		{
			get => _IsDone;
			set => Set(ref _IsDone, value);
		}
	}
}
