using CloudMining.Models.Base;

namespace CloudMining.Models
{
	internal class Device : NamedEntity
	{
		public string PurchaseDate { get; set; }
		public double hashrate { get; set; }
		public virtual Currency Currency { get; set; }
		public int consumption { get; set; }
	}
}
