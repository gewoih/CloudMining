using System.ComponentModel.DataAnnotations;

namespace CloudMining.Models.Base
{
	internal abstract class NamedEntity : Entity
	{
		[Required]
		public string Name { get; set; }
	}
}
