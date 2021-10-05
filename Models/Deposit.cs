namespace CloudMining.Models
{
	internal class Deposit : AOperation
	{
		public override int id { get; set; }
		public override string date { get; set; }
		public override double amount { get; set; }
		public override string comment { get; set; }
		public string fromMember { get; set; }

		public Deposit(
			int id,
			string date,
			double amount,
			string comment,
			string fromMember) : base(id, date, amount, comment)
		{
			this.fromMember = fromMember;
		}
	}
}
