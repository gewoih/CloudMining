using CloudMining.Models.Base;

namespace CloudMining.Models
{
	public class Purchase : Entity
	{
		public string Date { get; set; }
		public double Amount { get; set; }
		public string Subject { get; set; }
	}
}
