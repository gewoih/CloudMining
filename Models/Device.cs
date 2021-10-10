using CloudMining.Models.Base;

namespace CloudMining.Models
{
	public class Device : NamedEntity
	{
		public string PurchaseDate { get; set; }
		public double Hashrate { get; set; }
		public int CurrencyId { get; set; }
		public virtual Currency Currency { get; set; }
		public int Consumption { get; set; }
	}
}
