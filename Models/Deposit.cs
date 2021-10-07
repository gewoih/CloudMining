using CloudMining.Models.Base;

namespace CloudMining.Models
{
	internal class Deposit : Entity
	{
		public virtual Member Member { get; set; }
		public string Date { get; set; }
		public double Amount { get; set; }
		public string Comment { get; set; }
	}
}
